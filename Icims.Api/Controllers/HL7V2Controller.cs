using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Icims.Api.Models.Mirth;
using Icims.Common.Models.BusinessEngine;
using Icims.BusinessLayer;
using Microsoft.Extensions.Options;
using Icims.Common.Models.AppSettings;
using Icims.Common.Tools;
using Microsoft.Extensions.Logging;

namespace Icims.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HL7V2Controller : ControllerBase
  {
    private IBusinessEngine IBusinessEngine;
    private IBusinessEngineInput IBusinessEngineInput;
    private readonly IOptions<IcimsSiteContext> IcimsSiteContext;
    private readonly IMirthResponse IMirthResponse;
    private readonly ILogger<HL7V2Controller> ILogger;

    public HL7V2Controller(IBusinessEngine IBusinessEngine, 
      IBusinessEngineInput IBusinessEngineInput, 
      IOptions<IcimsSiteContext> IcimsSiteContext, 
      IMirthResponse IMirthResponse,
      ILogger<HL7V2Controller> ILogger)
    {      
      this.IBusinessEngine = IBusinessEngine;
      this.IBusinessEngineInput = IBusinessEngineInput;
      this.IcimsSiteContext = IcimsSiteContext;
      this.IMirthResponse = IMirthResponse;
      this.ILogger = ILogger;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<string> Get()
    {
      return $"Icims Service is Running: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";      
    }
    
    // POST api/values
    [HttpPost]
    public ActionResult<IMirthResponse> Post(MirthMessage MirthMessage)
    {
      //ILogger.LogTrace("Angus Did it work! Trace YES");
      //ILogger.LogDebug("Angus Did it work! Debug YES");
      //ILogger.LogError("Angus Did it work! Error YES");
      //ILogger.LogCritical("Angus Did it work! Critical YES");
      //ILogger.LogInformation("Angus Did it work! Info YES");      
      //ILogger.LogWarning("Angus Did it work! Warning YES");

      try
      {
        IBusinessEngineInput.HL7V2Message = MirthMessage.HL7V2Message;
        IBusinessEngineOutcome IBusinessOutcome = IBusinessEngine.Process(IBusinessEngineInput);
        IMirthResponse.StatusCode = IBusinessOutcome.StatusCode.GetLiteral();
        IMirthResponse.Message = IBusinessOutcome.Message;
        IMirthResponse.IcimsResponse = IBusinessOutcome.IcimsResponse;
        switch (IBusinessOutcome.StatusCode)
        {
          case Common.Models.BusinessModel.StatusCode.Ok:
            return Ok(IMirthResponse);
          case Common.Models.BusinessModel.StatusCode.Queue:
            return BadRequest(IMirthResponse);
          case Common.Models.BusinessModel.StatusCode.Error:
            return BadRequest(IMirthResponse);          
          default:
            throw new System.ComponentModel.InvalidEnumArgumentException(IBusinessOutcome.StatusCode.GetLiteral(), (int)IBusinessOutcome.StatusCode, typeof(Common.Models.BusinessModel.StatusCode));
        }               
      }
      catch(Exception Exec)
      {
        IMirthResponse.StatusCode = Common.Models.BusinessModel.StatusCode.Error.GetLiteral();
        IMirthResponse.Message = $"{IcimsSiteContext.Value.NameOfThisService}: Uncaught Exception: {Exec.Message}";
        IMirthResponse.IcimsResponse = null;
        return BadRequest(IMirthResponse);
      }      
    }

    
  }
}
