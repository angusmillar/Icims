using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.BusinessModel
{
  public class Address
  {
    public string AddressLineOne { get; set; }
    public string AddressLineTwo { get; set; }
    public string Suburb { get; set; }
    public string PostCode { get; set; }
    public string State { get; set; }
  }
}
