namespace Icims.Common.Models.BusinessEngine
{
  public interface IBusinessEngineOutcome
  {
    string ErrorMessage { get; set; }
    bool Success { get; set; }
  }
}