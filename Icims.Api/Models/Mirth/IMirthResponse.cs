using Icims.Common.Models.IcimsInterface;

namespace Icims.Api.Models.Mirth
{
  public interface IMirthResponse
  {
    string StatusCode { get; set; }
    string Message { get; set; }
    bool HasIcimsResponse { get; }
    IIcimsResponse IcimsResponse { get; set; }
  }
}