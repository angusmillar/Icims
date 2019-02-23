﻿using System;

namespace Icims.Common.Models.BusinessModel
{
  public class Patient
  {
    public Patient()
    {
      this.Address = new Address();
      this.ContactHome = new Contact();
      this.ContactBusiness = new Contact();
    }

    public string MedicalRecordNumber { get; set; }
    public string MedicalRecordNumberAssigningAuthorityCode { get; set; }

    public string Given { get; set; }
    public string Family { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public Address Address { get; set; }
    public Contact ContactHome { get; set; }
    public Contact ContactBusiness { get; set; }
    public string MaritalStatus { get; set; }
    public string Language { get; set; }
    public string Aboriginality { get; set; }
  }
}
