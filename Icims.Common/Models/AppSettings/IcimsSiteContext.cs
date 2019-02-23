using System;
using System.Collections.Generic;
using System.Text;

namespace Icims.Common.Models.AppSettings
{
  public class IcimsSiteContext
  {
    public string NameOfThisService { get; set; }
    public string PrimaryMRNAssigningAuthorityCode { get; set; }
    public string Endpoint { get; set; }
    public string AuthorizationToken { get; set; }
  }
}
