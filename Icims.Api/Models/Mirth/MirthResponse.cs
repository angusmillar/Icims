using Icims.Common.Models.IcimsInterface;

namespace Icims.Api.Models.Mirth
{
  public class MirthResponse : IMirthResponse
  {   
    public string StatusCode { get; set; }
    public string Message { get; set; }
    public bool HasIcimsResponse { get { return this.IcimsResponse != null; } }
    public IIcimsResponse IcimsResponse { get; set; }
  }

  

}
