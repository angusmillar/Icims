using System.Net;
using Icims.Common.Models.IcimsInterface;

namespace Icims.Common.Models.IcimsHttpClientModel
{
  public class IcimsHttpClientOutcome : IIcimsHttpClientOutcome
  {    
    public HttpStatusCode HttpStatusCode { get; set; }
    public string Message { get; set; }    
    public IIcimsResponse IcimsResponse { get; set; }
    public bool HasIcimsResponse
    {
      get
      {
        return this.IcimsResponse != null;
      }
    }

    
  }
}
