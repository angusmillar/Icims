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
    private readonly IBusinessEngineOutcome IBusinessOutcomeError;
    private readonly ILogger<HL7V2Controller> ILogger;

    public HL7V2Controller(IBusinessEngine IBusinessEngine, 
      IBusinessEngineInput IBusinessEngineInput, 
      IOptions<IcimsSiteContext> IcimsSiteContext,
      IBusinessEngineOutcome IBusinessOutcomeError,
      ILogger<HL7V2Controller> ILogger)
    {      
      this.IBusinessEngine = IBusinessEngine;
      this.IBusinessEngineInput = IBusinessEngineInput;
      this.IcimsSiteContext = IcimsSiteContext;
      this.IBusinessOutcomeError = IBusinessOutcomeError;
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
    public ActionResult<IBusinessEngineOutcome> Post(MirthMessage MirthMessage)
    {
      //ILogger.LogTrace("Angus Did it work! Trace YES");
      //ILogger.LogDebug("Angus Did it work! Debug YES");
      //ILogger.LogError("Angus Did it work! Error YES");
      //ILogger.LogCritical("Angus Did it work! Critical YES");
      //ILogger.LogInformation("Angus Did it work! Info YES");      
      //ILogger.LogWarning("Angus Did it work! Warning YES");
      IBusinessEngineOutcome IBusinessOutcome = null;
      try
      {
        IBusinessEngineInput.HL7V2Message = MirthMessage.HL7V2Message;
        IBusinessOutcome = IBusinessEngine.Process(IBusinessEngineInput);       
        switch (IBusinessOutcome.StatusCode)
        {
          case Common.Models.BusinessModel.StatusCode.ok:
            return Ok(IBusinessOutcome);
          case Common.Models.BusinessModel.StatusCode.queue:
            return BadRequest(IBusinessOutcome);
          case Common.Models.BusinessModel.StatusCode.error:
            return BadRequest(IBusinessOutcome);          
          default:
            throw new System.ComponentModel.InvalidEnumArgumentException(IBusinessOutcome.StatusCode.GetLiteral(), (int)IBusinessOutcome.StatusCode, typeof(Common.Models.BusinessModel.StatusCode));
        }               
      }
      catch(Exception Exec)
      {
        IBusinessOutcomeError.StatusCode = Common.Models.BusinessModel.StatusCode.error;
        IBusinessOutcomeError.Message = $"{IcimsSiteContext.Value.NameOfThisService}: Uncaught Exception: {Exec.Message}";
        IBusinessOutcomeError.IcimsResponse = null;
        ILogger.LogCritical(Exec, $"HL7 Msg: {MirthMessage.HL7V2Message}, Uncaught Exception: { Exec.Message}");
        return BadRequest(IBusinessOutcomeError);
      }      
    }

    
  }
}
