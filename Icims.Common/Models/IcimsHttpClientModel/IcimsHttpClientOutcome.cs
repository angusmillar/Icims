using System.Net;
using Icims.Common.Models.IcimsInterface;

namespace Icims.Common.Models.IcimsHttpClientModel
{
  public class IcimsHttpClientOutcome : IIcimsHttpClientOutcome
  {
    public bool IsSuccessStatusCode
    {
      get { return ((int)HttpStatusCode >= 200) && ((int)HttpStatusCode <= 299); }
    }
    public HttpStatusCode HttpStatusCode { get; set; }
    public IcimsResponse IcimsResponse { get; set; }
  }
}
