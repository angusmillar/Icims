using Icims.Common.Models.BusinessModel;
using Icims.Common.Models.IcimsInterface;

namespace Icims.Common.Models.BusinessEngine
{
  public interface IBusinessEngineOutcome
  {  
    StatusCode StatusCode { get; set; }
    string Message { get; set; }
    bool HasIcimsResponse { get; }
    IIcimsResponse IcimsResponse { get; set; }

  }
}