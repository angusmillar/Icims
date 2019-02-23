using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.BusinessModel
{
  public class Doctor
  {
    public Doctor()
    {
      this.Address = new Address();
      this.Contact = new Contact();
    }

    public string Given { get; set; }
    public string Family { get; set; }
    public Address Address { get; set; }
    public Contact Contact { get; set; }    
  }
}
