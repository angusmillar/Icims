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
    public Add MapToAdd(DomainModel Domain)
    {
      var Add = new Add();
      MapAddUpdate(Domain, Add as AddUpdateBase);
      return Add;
    }

    public Update MapToUpdate(DomainModel Domain)
    {
      var Update = new Update();
      MapAddUpdate(Domain, Update as AddUpdateBase);
      return Update;
    }

    public Merge MapToMerge(DomainModel Domain)
    {
      var Merge = new Merge();
      MapMerge(Domain, Merge);
      return Merge;
    }

    private void MapAddUpdate(DomainModel Domain, AddUpdateBase AddUpdate)
    {
      MapBase(Domain, AddUpdate as IcimsModelBase);

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

    private void MapMerge(DomainModel Domain, Merge Merge)
    {
      MapBase(Domain, Merge as IcimsModelBase);
      Merge.prior_ur = Domain.Patient.PriorMRN.Value;
      Merge.prior_assigning_authority = Domain.Patient.PriorMRN.AssigningAuthorityCode;
    }

    private void MapBase(DomainModel Domain, IcimsModelBase Base)
    {
      //Message
      Base.msgid = Domain.HL7Message.MessageControlId;
      Base.msg_datetime = Domain.HL7Message.MessageDateTime.ToString("yyyy-MM-ddTHH:mm:ss");

      //Patient
      Base.ur_num = Domain.Patient.PrimaryMRN.Value;
      Base.assigning_authority = Domain.Patient.PrimaryMRN.AssigningAuthorityCode;

      Base.surname = Domain.Patient.Family;
      Base.fname = Domain.Patient.Given;
      if (Domain.Patient.DateOfBirth != null)
      {
        Base.dob = Domain.Patient.DateOfBirth.ToString("yyyy-MM-dd");
      }
      Base.sex = Domain.Patient.Gender.GetLiteral();

      //Model.phone = "";
      if (Domain.Patient.ContactHome != null)
      {
        if (Domain.Patient.ContactHome.PhoneList.Count > 0)
        {
          Base.phone = Domain.Patient.ContactHome.PhoneList[0];
        }
      }
      if (Base.phone == string.Empty && Domain.Patient.ContactBusiness != null)
      {
        if (Domain.Patient.ContactBusiness.PhoneList.Count > 0)
        {
          Base.phone = Domain.Patient.ContactBusiness.PhoneList[0];
        }
      }

      //Model.mobile = "";
      if (Domain.Patient.ContactHome != null)
      {
        if (Domain.Patient.ContactHome.MobileList.Count > 0)
        {
          Base.mobile = Domain.Patient.ContactHome.MobileList[0];
        }
      }
      if (Base.mobile == null && Domain.Patient.ContactBusiness != null)
      {
        if (Domain.Patient.ContactBusiness.MobileList.Count > 0)
        {
          Base.mobile = Domain.Patient.ContactBusiness.MobileList[0];
        }
      }


      Base.language = Domain.Patient.Language;
      Base.marital_status = Domain.Patient.MaritalStatus;
      Base.aboriginality = Domain.Patient.Aboriginality;

      if (Domain.Patient.Address != null)
      {
        Base.addr_line_1 = Domain.Patient.Address.AddressLineOne;
        Base.addr_line_2 = Domain.Patient.Address.AddressLineTwo;
        Base.suburb = Domain.Patient.Address.Suburb;
        Base.postcode = Domain.Patient.Address.PostCode;
        Base.state = Domain.Patient.Address.State;
      }
    }
  }
}
