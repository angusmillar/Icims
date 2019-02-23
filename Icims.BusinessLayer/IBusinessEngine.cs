using Icims.Common.Models.BusinessEngine;

namespace Icims.BusinessLayer
{
  public interface IBusinessEngine
  {
    IBusinessEngineOutcome Process(IBusinessEngineInput BusinessEngineInput);
  }
}