using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Icims.Common.Models.IcimsInterface;

namespace Icims.MocekedIcimsEndpoint.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MockController : ControllerBase
  {
    // GET api/values
    [HttpGet]
    public ActionResult<string> Get()
    {
      return "Icims Mocked Service running";
    }


    //// POST api/values
    //[HttpPost]    
    //[Consumes("application/x-www-form-urlencoded")]
    //public void Post([FromForm]IFormCollection type)
    //{
    //  string Data;
    //  Microsoft.Extensions.Primitives.StringValues Fname = new Microsoft.Extensions.Primitives.StringValues();
    //  if(type.TryGetValue("fname", out Fname))
    //  {
    //    Data = Fname.First();
    //  }
    //}

    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    [Route("add")]
    public void PostAdd([FromForm]Add AddData)
    {
      string Fname = AddData.fname;
    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    [Route("update")]
    public IActionResult PostUpdate([FromForm]Update UpdateData)
    {
      string Fname = UpdateData.fname;
      IcimsResponse Response = new IcimsResponse();
      Response.state = "Ok";
      Response.error = "No Error";
      return Ok(Response); 
    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    [Route("merge")]
    public void PostMerge([FromForm]Merge MergeData)
    {
      string Fname = MergeData.fname;
    }
  }
}
