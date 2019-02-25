﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Icims.Api.Models.Mirth;
using Icims.Common.Models.BusinessEngine;
using Icims.BusinessLayer;
using Microsoft.Extensions.Options;
using Icims.Common.Models.AppSettings;

namespace Icims.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HL7V2Controller : ControllerBase
  {
    private IBusinessEngine IBusinessEngine;
    private IBusinessEngineInput IBusinessEngineInput;
    private readonly IOptions<IcimsSiteContext> IcimsSiteContext;
    public HL7V2Controller(IBusinessEngine IBusinessEngine, IBusinessEngineInput IBusinessEngineInput, IOptions<IcimsSiteContext> IcimsSiteContext)
    {      
      this.IBusinessEngine = IBusinessEngine;
      this.IBusinessEngineInput = IBusinessEngineInput;
      this.IcimsSiteContext = IcimsSiteContext;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<string> Get()
    {
      return $"Icims Service is Running: {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";      
    }
    
    // POST api/values
    [HttpPost]
    public ActionResult<MirthResponse> Post(MirthMessage MirthMessage)
    {
      var Response = new MirthResponse();
      try
      {
        IBusinessEngineInput.HL7V2Message = MirthMessage.HL7V2Message;
        IBusinessEngineOutcome IBusinessOutcome = IBusinessEngine.Process(IBusinessEngineInput);
        Response.Success = IBusinessOutcome.Success;
        Response.ErrorMessage = IBusinessOutcome.ErrorMessage;
        if (Response.Success)
        {
          return Ok(Response);
        }
        else
        {
          return BadRequest(Response);
        }        
      }
      catch(Exception Exec)
      {
        Response.Success = false;
        Response.ErrorMessage = $"{IcimsSiteContext.Value.NameOfThisService}: Uncaught Exception: {Exec.Message}";
        return BadRequest(Response);
      }      
    }

    
  }
}
