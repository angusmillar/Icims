using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icims.Common.Models.BusinessEngine
{
  public class BusinessEngineOutcome : IBusinessEngineOutcome
  {
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
  }
}
