using Icims.Common.Models.BusinessModel;
using Icims.Common.Models.IcimsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icims.Common.Models.BusinessEngine
{
  public class BusinessEngineOutcome : IBusinessEngineOutcome
  {
    public StatusCode StatusCode { get; set; }    
    public string Message { get; set; }
    public bool HasIcimsResponse { get { return this.IcimsResponse != null; } }
    public IIcimsResponse IcimsResponse { get; set; }
  }
}
