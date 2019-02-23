using Icims.Common.Models.BusinessModel;
using Icims.Common.Models.IcimsInterface;
using Icims.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.BusinessLayer
{
  public class IcimsInterfaceModelMapper : IIcimsInterfaceModelMapper
  {
    public Update MapToUpdate(DomainModel Domain)
    {
      var Update = new Update();
      MapAddUpdate(Domain, Update as AddUpdateBase);      
      return Update;
    }

    public Add MapToAdd(DomainModel Domain)
    {
      var Add = new Add();
      MapAddUpdate(Domain, Add as AddUpdateBase);
      return Add;
    }

    private void MapAddUpdate(DomainModel Domain, AddUpdateBase AddUpdate)
    {
      //Message
      AddUpdate.msgid = Domain.HL7Message.MessageControlId;
      AddUpdate.msg_datetime = Domain.HL7Message.MessageDateTime.ToString("yyyy-MM-ddTHH:mm:ss");

      //Patient
      AddUpdate.ur_num = Domain.Patient.MedicalRecordNumber;
      AddUpdate.assigning_authority = Domain.Patient.MedicalRecordNumberAssigningAuthorityCode;

      AddUpdate.surname = Domain.Patient.Family;
      AddUpdate.fname = Domain.Patient.Given;
      if (Domain.Patient.DateOfBirth != null)
      {
        AddUpdate.dob = Domain.Patient.DateOfBirth.ToString("yyyy-MM-dd");
      }      
      AddUpdate.sex = Domain.Patient.Gender.GetLiteral();

      //Model.phone = "";
      if (Domain.Patient.ContactHome != null)
      {
        if (Domain.Patient.ContactHome.PhoneList.Count > 0)
        {
          AddUpdate.phone = Domain.Patient.ContactHome.PhoneList[0];
        }
      }
      if (AddUpdate.phone == string.Empty && Domain.Patient.ContactBusiness != null)
      {
        if (Domain.Patient.ContactBusiness.PhoneList.Count > 0)
        {
          AddUpdate.phone = Domain.Patient.ContactBusiness.PhoneList[0];
        }
      }
      
      //Model.mobile = "";
      if (Domain.Patient.ContactHome != null)
      {
        if (Domain.Patient.ContactHome.MobileList.Count > 0)
        {
          AddUpdate.mobile = Domain.Patient.ContactHome.MobileList[0];
        }
      }
      if (AddUpdate.mobile == null && Domain.Patient.ContactBusiness != null)
      {
        if (Domain.Patient.ContactBusiness.MobileList.Count > 0)
        {
          AddUpdate.mobile = Domain.Patient.ContactBusiness.MobileList[0];
        }
      }


      AddUpdate.language = Domain.Patient.Language;
      AddUpdate.marital_status = Domain.Patient.MaritalStatus;
      AddUpdate.aboriginality = Domain.Patient.Aboriginality;

      if (Domain.Patient.Address != null)
      {
        AddUpdate.addr_line_1 = Domain.Patient.Address.AddressLineOne;
        AddUpdate.addr_line_2 = Domain.Patient.Address.AddressLineTwo;
        AddUpdate.suburb = Domain.Patient.Address.Suburb;
        AddUpdate.postcode = Domain.Patient.Address.PostCode;
        AddUpdate.state = Domain.Patient.Address.State;
      }

      //Doctor
      if (Domain.Doctor != null)
      {
        AddUpdate.gp_surname = Domain.Doctor.Family;
        AddUpdate.gp_fname = Domain.Doctor.Given;

        if (Domain.Doctor.Contact != null)
        {
          if (Domain.Doctor.Contact.EmailList.Count > 0)
          {
            AddUpdate.gp_email = Domain.Doctor.Contact.EmailList[0];
          }
          if (Domain.Doctor.Contact.FaxList.Count > 0)
          {
            AddUpdate.gp_fax = Domain.Doctor.Contact.FaxList[0];
          }
        }
        
        if (Domain.Doctor.Address != null)
        {
          AddUpdate.gp_addr_line_1 = Domain.Doctor.Address.AddressLineOne;
          AddUpdate.gp_addr_line_2 = Domain.Doctor.Address.AddressLineTwo;
          AddUpdate.gp_suburb = Domain.Doctor.Address.Suburb;
          AddUpdate.gp_postcode = Domain.Doctor.Address.PostCode;
          AddUpdate.gp_state = Domain.Doctor.Address.State;
        }
        
      }

    }
  }
}
