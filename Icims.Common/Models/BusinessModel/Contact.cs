using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.BusinessModel
{
  public class Contact
  {
    public Contact()
    {
      this.PhoneList = new List<string>();
      this.MobileList = new List<string>();
      this.EmailList = new List<string>();
      this.FaxList = new List<string>();
    }

    public List<string> PhoneList { get; set; }
    public List<string> MobileList { get; set; }
    public List<string> EmailList { get; set; }
    public List<string> FaxList { get; set; }
  }
}
