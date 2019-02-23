using Icims.Common.Models.AppSettings;
using Icims.Common.Models.BusinessEngine;
using Icims.Common.Models.BusinessModel;
using Icims.Common.Tools;
using Microsoft.Extensions.Options;
using PeterPiper.Hl7.V2.Model;
using System;
using System.Threading.Tasks;

namespace Icims.BusinessLayer
{
  public class BusinessEngine : IBusinessEngine
  {
    private readonly IOptions<IcimsSiteContext> IcimsSiteContext;
    private readonly IBusinessEngineOutcome IBusinessOutcome;
    private readonly IIcimsInterfaceModelMapper IIcimsInterfaceModelMapper;
    private readonly IIcimsHttpClient IIcimsHttpClient;
    private DomainModel DomainModel;
    private IMessage Msg;

    public BusinessEngine(IOptions<IcimsSiteContext> IcimsSiteContext, 
      IBusinessEngineOutcome IBusinessOutcome, 
      IIcimsInterfaceModelMapper IIcimsInterfaceModelMapper,
      IIcimsHttpClient IIcimsHttpClient)
    {
      this.IcimsSiteContext = IcimsSiteContext;
      this.IBusinessOutcome = IBusinessOutcome;
      this.IIcimsInterfaceModelMapper = IIcimsInterfaceModelMapper;
      this.IIcimsHttpClient = IIcimsHttpClient;
    }

    public IBusinessEngineOutcome Process(IBusinessEngineInput BusinessEngineInput)
    {
      //Parse the V2 Message
      try
      {
        Msg = Creator.Message(BusinessEngineInput.HL7V2Message);
      }
      catch (Exception Exec)
      {
        IBusinessOutcome.Success = false;
        IBusinessOutcome.ErrorMessage = Exec.Message;
        return IBusinessOutcome;
      }

      //Check it is an ADT message type
      if (Msg.MessageType != "ADT")
      {
        IBusinessOutcome.Success = false;
        IBusinessOutcome.ErrorMessage = $"Only message types of ADT are supported by the {IcimsSiteContext.Value.NameOfThisService}. The message type received was {Msg.MessageType}";
        return IBusinessOutcome;
      }

      DomainModel = new DomainModel();
      DomainModel.HL7Message.MessageControlId = Msg.MessageControlID;
      DomainModel.HL7Message.MessageDateTime = Msg.MessageCreationDateTime;

      switch (Msg.MessageTrigger)
      {
        case "A04":
          if (!AddProcessing())
          {
            return IBusinessOutcome;
          }
          break;
        case "A08":
          if (!UpdateProcessing())
          {
            return IBusinessOutcome;
          }
          else
          {
            Common.Models.IcimsInterface.Update Update = IIcimsInterfaceModelMapper.MapToUpdate(DomainModel);
            Task<bool> x = IIcimsHttpClient.PostUpdateAsync(Update);
            x.Wait();
            var zz = x.Result;
          }
          break;
        case "A40":
          if (!MergeProcessing())
          {
            return IBusinessOutcome;
          }
          break;
        default:
          IBusinessOutcome.Success = false;
          IBusinessOutcome.ErrorMessage = $"Only ADT message of event types A04. A08 and A40 are supported by the {IcimsSiteContext.Value.NameOfThisService}. The message event received was {Msg.MessageTrigger}";
          return IBusinessOutcome;
      }

      //NOw the DomainModel is successfully populated, time to map to Icims Interface Model


      return IBusinessOutcome;
    }

    private bool AddProcessing()
    {
      DomainModel.Action = PostActionType.Add;
      PopulatePatient();
      return true;

    }

    private bool UpdateProcessing()
    {
      DomainModel.Action = PostActionType.Update;
      if (!PopulatePatient())
      {
        return false;
      }
      if (!PopulateDoctor())
      {
        return false;
      }
      return true;
    }

    private bool MergeProcessing()
    {
      return true;
    }

    private bool PopulatePatient()
    {
      //Check there is a PID segment with the patient info
      if (Msg.SegmentCount("PID") != 1)
      {
        IBusinessOutcome.Success = false;
        IBusinessOutcome.ErrorMessage = $"There is either none or more than one PID segment in the received message. PID segment count was : {Msg.SegmentCount("PID")}. There must be one and only one PID segment.";
        return false;
      }

      var PID = Msg.Segment("PID");      
      if (!ResolveMedicalRecordNumber(Msg.Segment("PID").Element(3)))
      {
        return false;
      }      

      //Patient Name
      foreach (var oXPN in PID.Element(5).RepeatList)
      {
        if (oXPN.Component(7).AsString.ToUpper() == "L")
        {
          DomainModel.Patient.Given = oXPN.Component(2).AsString;
          DomainModel.Patient.Family = oXPN.Component(1).AsString;
        }
      }

      //Dob
      //Patient Date of Birth
      //require: dd/mm/yyyy
      if (!PID.Field(7).IsEmpty && !PID.Field(7).IsHL7Null)
      {
        if (PID.Field(7).Convert.DateTime.CanParseToDateTimeOffset)
        {
          DateTimeOffset DOB = PID.Field(7).Convert.DateTime.GetDateTimeOffset();
          DomainModel.Patient.DateOfBirth = DOB.Date;
        }
        else
        {
          IBusinessOutcome.Success = false;
          IBusinessOutcome.ErrorMessage = $"Unable to convert the patient date of birth to a valid date. The valid found was: {PID.Field(7).AsString}";
          return false;
        }
      }

      //Patient Sex
      if (!PID.Field(8).IsEmpty && !PID.Field(8).IsHL7Null)
      {
        switch (PID.Field(8).AsString)
        {
          case "M":
            DomainModel.Patient.Gender = Gender.Male;
            break;
          case "F":
            DomainModel.Patient.Gender = Gender.Female;
            break;
          case "O":
            DomainModel.Patient.Gender = Gender.Other;
            break;
          case "U":
            DomainModel.Patient.Gender = Gender.Unknown;
            break;
          default:
            IBusinessOutcome.Success = false;
            IBusinessOutcome.ErrorMessage = $"Unknown patient gender code. Code found was : {PID.Field(8).AsString}";
            return false;
        }
      }

      //ToDo: Here we seem to send the whole Field e.g 5^Married^MARRY, is this correct
      DomainModel.Patient.MaritalStatus = PID.Field(16).AsString;
      //ToDo: Here we seem to send the whole Field e.g 1201^English^SPOKL, is this correct
      DomainModel.Patient.Language = PID.Field(15).AsString;

      DomainModel.Patient.Aboriginality = PID.Field(10).Component(1).AsString;

      //Get single Address by type from possible address list of many
      ResolveAddress(PID.Element(11), DomainModel.Patient.Address);

      //Get Contacts
      ResolveContact(PID.Element(13), DomainModel.Patient.ContactHome, PhoneUseType.Primary.GetLiteral());
      ResolveContact(PID.Element(14), DomainModel.Patient.ContactBusiness, PhoneUseType.Work.GetLiteral());

      return true;

    }

    private bool PopulateDoctor()
    {
      var ProviderRole = "PP";
      var ProviderType = "GMPRC";
      ISegment TargetRolSegment = null;
      foreach (var ROL in Msg.SegmentList("ROL"))
      {               
        if (ROL.Field(3).Component(1).AsString.ToUpper() == ProviderRole &&
            ROL.Field(9).Component(1).AsString.ToUpper() == ProviderType)
        {
          TargetRolSegment = ROL;
        }
      }

      if (TargetRolSegment == null)
      {
        //It is not an error to have no doctor, at least this is true for RMH
        DomainModel.Doctor = null;
        return true;
      }
      else
      {       
        DomainModel.Doctor.Given = TargetRolSegment.Field(4).Component(3).AsString;
        DomainModel.Doctor.Family = TargetRolSegment.Field(4).Component(2).AsString;

        //Doctor Address
        //(1: Business, 2: Mailing Address, 3:Temporary Address, 4:Residential/Home, 9: Not Specified)
        //At RMH we had issues in that we got many addresses and could not pick the one required for the current primary doctor surgery
        //This was resolved and the PMI is to now only send a single address that being the correct address.
        //For this reason I have changes the code below to just take the first address regardless of there being many, which there should not be.

        //If we did not get the target address then just take the first address.
        if (TargetRolSegment.Element(11).RepeatCount > 0)
        {
          ResolveAddress(TargetRolSegment.Element(11), DomainModel.Doctor.Address);
        }

        //Doctor Contacts (We only take the first of each type.
        ResolveContact(TargetRolSegment.Element(12), DomainModel.Doctor.Contact, PhoneUseType.Work.GetLiteral());

        return true;
      }            
    }

    private bool ResolveContact(IElement ContactElement, Contact Contact, string UseTypeCode)
    {          
      foreach (var oXTN in ContactElement.RepeatList)
      {
        if (oXTN.Component(2).AsString.ToUpper() == UseTypeCode &&
            oXTN.Component(3).AsString.ToUpper() == PhoneEquipmentType.Telephone.GetLiteral())
        {
          if (!oXTN.Component(1).IsEmpty)
          {
            Contact.PhoneList.Add(oXTN.Component(1).AsString);           
          }
        }
        //Primary Mobile
        if (oXTN.Component(2).AsString.ToUpper() == UseTypeCode &&
            oXTN.Component(3).AsString.ToUpper() == PhoneEquipmentType.Mobile.GetLiteral())
        {
          if (!oXTN.Component(1).IsEmpty)
          {
            Contact.MobileList.Add(oXTN.Component(1).AsString);           
          }
        }
        //Primary Fax
        if (oXTN.Component(2).AsString.ToUpper() == UseTypeCode &&
            oXTN.Component(3).AsString.ToUpper() == PhoneEquipmentType.FacsimileMachine.GetLiteral())
        {
          if (!oXTN.Component(1).IsEmpty)
          {
            Contact.FaxList.Add(oXTN.Component(1).AsString);           
          }
        }
        //Primary Email (Correct Version) e.g ^NET^INTERNET^info@westgatemedical.com.au
        if (oXTN.Component(2).AsString.ToUpper() == PhoneUseType.EmailAddress.GetLiteral() &&
            oXTN.Component(3).AsString.ToUpper() == PhoneEquipmentType.Internet.GetLiteral())
        {
          if (!oXTN.Component(1).IsEmpty)
          {
            Contact.EmailList.Add(oXTN.Component(1).AsString);           
          }
        }
        //Primary Email (Incorrect Version on Patients at RMH) e.g angus.millar@iinet.net.au^PRN^NET
        if (oXTN.Component(2).AsString.ToUpper() == UseTypeCode &&
            oXTN.Component(3).AsString.ToUpper() == PhoneUseType.EmailAddress.GetLiteral())
        {
          if (!oXTN.Component(1).IsEmpty)
          {
            Contact.EmailList.Add(oXTN.Component(1).AsString);            
          }
        }
      }
      return true;
    }

    private bool ResolveAddress(IElement AddressElement, Address Address)
    {
      if (AddressElement.RepeatList.Count == 0)
      {        
        return true;
      }
      else
      {
        IField TargetAddress = null;
        foreach (var oXAD in AddressElement.RepeatList)
        {
          if (oXAD.Component(7).AsString == AddressType.ResidentialHome.GetLiteral())
          {
            TargetAddress = oXAD;
          }
          else if (oXAD.Component(7).AsString == AddressType.Business.GetLiteral())
          {
            TargetAddress = oXAD;
          }
          else if (oXAD.Component(7).AsString == AddressType.MailingAddress.GetLiteral())
          {
            TargetAddress = oXAD;
          }
          else if (oXAD.Component(7).AsString == AddressType.TemporaryAddress.GetLiteral())
          {
            TargetAddress = oXAD;
          }
        }
        if (TargetAddress == null)
        {
          TargetAddress = AddressElement.RepeatList[0];
        }
        
        Address.AddressLineOne = TargetAddress.Component(1).AsString;
        Address.AddressLineTwo = TargetAddress.Component(2).AsString;
        Address.Suburb = TargetAddress.Component(3).AsString;
        Address.State = TargetAddress.Component(4).AsString;
        Address.PostCode = TargetAddress.Component(5).AsString;
      }
      return true;
    }

    private bool ResolveMedicalRecordNumber(IElement PID3)
    {
      string Value = string.Empty;
      string AssigningAuthority = string.Empty;

      string FirstMRValue = string.Empty;
      string FirstMRAssigningAuthority = string.Empty;

      foreach (var oCX in PID3.RepeatList)
      {
        if (oCX.Component(5).AsString.ToUpper() == "MR" &&
          oCX.Component(4).AsString.ToUpper() == IcimsSiteContext.Value.PrimaryMRNAssigningAuthorityCode &&
          oCX.Component(8).AsString == string.Empty)
        {
          Value = oCX.Component(1).AsString;
          AssigningAuthority = oCX.Component(4).AsString;
        }
        else if (oCX.Component(5).AsString.ToUpper() == "MR" &&
                 oCX.Component(8).AsString == string.Empty &&
                 FirstMRValue == string.Empty)
        {
          FirstMRValue = oCX.Component(1).AsString;
          FirstMRAssigningAuthority = oCX.Component(4).AsString;
        }
      }
      if (FirstMRValue != string.Empty && FirstMRAssigningAuthority == string.Empty)
      {
        //We found no MRN Value for the given Assigning Auth of RMH so
        //take the first Value of MR type as long as it had no Assigning Auth
        // and assume it ids RMH
        Value = FirstMRValue;
        AssigningAuthority = IcimsSiteContext.Value.PrimaryMRNAssigningAuthorityCode;
      }

      if (Value == string.Empty)
      {
        IBusinessOutcome.Success = false;
        IBusinessOutcome.ErrorMessage = $"Unable to locate the primary medical record number in PID-3. Either many are marked as 'MR' and have no AssigningAuthority code or none have the AssigningAuthority code of {IcimsSiteContext.Value.PrimaryMRNAssigningAuthorityCode}.";
        return false;
      }
      DomainModel.Patient.MedicalRecordNumber = Value;
      DomainModel.Patient.MedicalRecordNumberAssigningAuthorityCode = AssigningAuthority;
      return true;
    }
  }
}
