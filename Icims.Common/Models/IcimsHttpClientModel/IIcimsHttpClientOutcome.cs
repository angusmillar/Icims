using System.Net;
using Icims.Common.Models.IcimsInterface;

namespace Icims.Common.Models.IcimsHttpClientModel
{
  public interface IIcimsHttpClientOutcome
  {
    bool IsSuccessStatusCode { get; }    
    HttpStatusCode HttpStatusCode { get; set; }
    IcimsResponse IcimsResponse { get; set; }
  }
}