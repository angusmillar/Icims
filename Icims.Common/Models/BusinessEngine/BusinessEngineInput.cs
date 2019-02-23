using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icims.Common.Models.BusinessEngine
{
  public class BusinessEngineInput : IBusinessEngineInput
  {
    public string HL7V2Message { get; set; }
  }
}
