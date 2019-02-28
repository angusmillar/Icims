using System.Net;
using Icims.Common.Models.IcimsInterface;

namespace Icims.Common.Models.IcimsHttpClientModel
{
  public interface IIcimsHttpClientOutcome
  {     
    HttpStatusCode HttpStatusCode { get; set; }
    string Message { get; set; }
    bool HasIcimsResponse { get; }
    IIcimsResponse IcimsResponse { get; set; }
  }
}