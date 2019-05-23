using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Icims.Common.Models.IcimsInterface;
using Icims.Common.Models.BusinessModel;
using Icims.Common.Tools;

namespace Icims.MocekedIcimsEndpoint.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MockController : ControllerBase
  {
    private readonly string Update = PostActionType.Update.GetLiteral();

    // GET api/values
    [HttpGet]
    public ActionResult<string> Get()
    {
      return "Icims Mocked Service running";
    }
    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    //Below must be the same as the enum Icims.Common.Tools.PostActionType.add.GetLiteral();
    [Route("addpatient")]
    public IActionResult PostAdd([FromForm]Add Data)
    {
      //As per the HL7 V2 Message Resource named 'RMH_ADT_A04.hl7' 
      var Response = new IcimsResponse();
      //If the Message ID is the known test message check the values
      //otherwise just return OK
      if (Data.msgid == "22045529")
      {
        if (!TestValue("action", Data.action, "addpatient", out Response)) return BadRequest(Response);

        if (!TestValue("msgid", Data.msgid, "22045529", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2017-01-30T16:29:37", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "0000001", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "RMH", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "TestGivenOne", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "TestSurnameOne", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1950-01-01T00:00:00", out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, null, out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "0412345678", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, "8714", out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "2", out Response)) return BadRequest(Response);
        if (!TestValue("aboriginality", Data.aboriginality, "4", out Response)) return BadRequest(Response);

        if (!TestValue("addr_line_1", Data.addr_line_1, "10 Test St", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "3220", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Geelong", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, "VIC", out Response)) return BadRequest(Response);

        if (!TestValue("gp_fname", Data.gp_fname, "TESTDrGiven", out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, "TESTDrSurname", out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, "93 Macleod Street", out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, "3875", out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, "BAIRNSDALE", out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, "VIC", out Response)) return BadRequest(Response);

        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, "03  4321 4321", out Response)) return BadRequest(Response);
      }

      //SAH - A05 - 18848924
      if (Data.msgid == "18848924")
      {
        if (!TestValue("action", Data.action, "addpatient", out Response)) return BadRequest(Response);

        if (!TestValue("msgid", Data.msgid, "18848924", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-08T12:10:11", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "559524", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "Carole Jean", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Trudgett", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "F", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1938-12-15", out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, "0416229784", out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "02 99791496", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "W", out Response)) return BadRequest(Response);
        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);

        if (!TestValue("addr_line_1", Data.addr_line_1, "12/122 Carrington Road", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2102", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Warriewood", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_fname", Data.gp_fname, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
      }
      
      return Ok(new IcimsResponse() { state = "Ok", error = "No Error" });

    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    //Below must be the same as the enum Icims.Common.Tools.PostActionType.update.GetLiteral();
    [Route("updatepatient")]
    public IActionResult PostUpdate([FromForm]Update Data)
    {
      //As per the HL7 V2 Message Resource named 'RMH_ADT_A08.hl7' 
      var Response = new IcimsResponse();

      //If the Message ID is the known test message check the values
      //otherwise just return OK
      if (Data.msgid == "330465171")
      {
        if (!TestValue("aboriginality", Data.aboriginality, "4", out Response)) return BadRequest(Response);
        if (!TestValue("action", Data.action, "updatepatient", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_1", Data.addr_line_1, "5 Melrose Ct", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "RMH", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1987-02-23T00:00:00", out Response)) return BadRequest(Response);
        if (!TestValue("fname", Data.fname, "James", out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fname", Data.gp_fname, "Jeff", out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, "Szer", out Response)) return BadRequest(Response);
        if (!TestValue("language", Data.language, "1201", out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "5", out Response)) return BadRequest(Response);
        if (!TestValue("mobile", Data.mobile, null, out Response)) return BadRequest(Response);
        if (!TestValue("msgid", Data.msgid, "330465171", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2017-04-03T12:24:46", out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "0405220921", out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "3155", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, "VIC", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Scarborough", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Scanlan", out Response)) return BadRequest(Response);
        if (!TestValue("ur_num", Data.ur_num, "3008781", out Response)) return BadRequest(Response);
      }

      //SAH - A01 - 18848924
      if (Data.msgid == "18848930")
      {
        if (!TestValue("action", Data.action, "updatepatient", out Response)) return BadRequest(Response);

        if (!TestValue("msgid", Data.msgid, "18848930", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-08T12:11:18", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "559524", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("MedicareNumberValue", Data.MedicareNumberValue, "22327727271", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "Carole Jean", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Trudgett", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "F", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1938-12-15", out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, "0416229784", out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "02 99791496", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "W", out Response)) return BadRequest(Response);
        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);

        if (!TestValue("addr_line_1", Data.addr_line_1, "12/122 Carrington Road", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2102", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Warriewood", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_fname", Data.gp_fname, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
      }
      
      //SAH - A02 - 18848932
      if (Data.msgid == "18848932")
      {
        if (!TestValue("msgid", Data.msgid, "18848932", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-08T12:21:31", out Response)) return BadRequest(Response);
        if (!TestValue("action", Data.action, "updatepatient", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "672433", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("surname", Data.surname, "Smith", out Response)) return BadRequest(Response);
        if (!TestValue("fname", Data.fname, "Joshua", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1995-08-11", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);

        if (!TestValue("phone", Data.phone, "02 94997065", out Response)) return BadRequest(Response);
        if (!TestValue("mobile", Data.mobile, "0447504778", out Response)) return BadRequest(Response);

        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);
        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "S", out Response)) return BadRequest(Response);
      
        if (!TestValue("addr_line_1", Data.addr_line_1, "25 Alice Street", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2071", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Killara", out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fname", Data.gp_fname, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, null, out Response)) return BadRequest(Response);
        
      }

      //SAH - A03 - 18848934
      if (Data.msgid == "18848934")
      {
        if (!TestValue("action", Data.action, "updatepatient", out Response)) return BadRequest(Response);

        if (!TestValue("msgid", Data.msgid, "18848934", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-08T12:22:13", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "672433", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "Joshua", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Smith", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1995-08-11", out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, "0447504778", out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "02 94997065", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "S", out Response)) return BadRequest(Response);
        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);

        if (!TestValue("addr_line_1", Data.addr_line_1, "25 Alice Street", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2071", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Killara", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_fname", Data.gp_fname, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
      }

      //SAH - A08 - 18846016
      if (Data.msgid == "18846016")
      {
        if (!TestValue("action", Data.action, "updatepatient", out Response)) return BadRequest(Response);

        if (!TestValue("msgid", Data.msgid, "18846016", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-06T12:26:52", out Response)) return BadRequest(Response);

        if (!TestValue("ur_num", Data.ur_num, "625881", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "Nancy", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Rusev", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "F", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1946-01-21", out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, null, out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "02 98882894", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "W", out Response)) return BadRequest(Response);
        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);

        if (!TestValue("addr_line_1", Data.addr_line_1, "11 Feathertail Place", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2113", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "North Ryde", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_fname", Data.gp_fname, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_surname", Data.gp_surname, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_addr_line_1", Data.gp_addr_line_1, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_addr_line_2", Data.gp_addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_postcode", Data.gp_postcode, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_suburb", Data.gp_suburb, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_state", Data.gp_state, null, out Response)) return BadRequest(Response);

        if (!TestValue("gp_email", Data.gp_email, null, out Response)) return BadRequest(Response);
        if (!TestValue("gp_fax", Data.gp_fax, null, out Response)) return BadRequest(Response);
      }

      return Ok(new IcimsResponse() { state = "Ok", error = "No Error" });
      
     //Debug force error
     //return BadRequest(new IcimsResponse() { state = "Error", error = "Testing Only" });

    }
    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    //Below must be the same as the enum Icims.Common.Tools.PostActionType.merge.GetLiteral();
    [Route("mergepatient")]
    public IActionResult PostMerge([FromForm]Merge Data)
    {
      //As per the HL7 V2 Message Resource named 'RMH_ADT_A40.hl7' 
      var Response = new IcimsResponse();

      //If the Message ID is the known test message check the values
      //otherwise just return OK
      if (Data.msgid == "344318446")
      {
        if (!TestValue("aboriginality", Data.aboriginality, "4", out Response)) return BadRequest(Response);
        if (!TestValue("action", Data.action, "mergepatient", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_1", Data.addr_line_1, "160/100 Broadway", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "RMH", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1941-11-29T00:00:00", out Response)) return BadRequest(Response);
        if (!TestValue("fname", Data.fname, "Giuseppe", out Response)) return BadRequest(Response);
        if (!TestValue("language", Data.language, "2401", out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "4", out Response)) return BadRequest(Response);
        if (!TestValue("mobile", Data.mobile, null, out Response)) return BadRequest(Response);
        if (!TestValue("msgid", Data.msgid, "344318446", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2013-11-28T14:58:11", out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "0424 916 769", out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "3196", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, "VIC", out Response)) return BadRequest(Response);
        if (!TestValue("suburb", Data.suburb, "Chelsea", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Cantaro", out Response)) return BadRequest(Response);
        if (!TestValue("ur_num", Data.ur_num, "0255736", out Response)) return BadRequest(Response);

        if (!TestValue("prior_ur", Data.prior_ur, "TMP6612049", out Response)) return BadRequest(Response);
        if (!TestValue("prior_assigning_authority", Data.prior_assigning_authority, "RMH", out Response)) return BadRequest(Response);
      }

      if (Data.msgid == "18849620")
      {
        if (!TestValue("aboriginality", Data.aboriginality, null, out Response)) return BadRequest(Response);
        if (!TestValue("msgid", Data.msgid, "18849620", out Response)) return BadRequest(Response);
        if (!TestValue("msg_datetime", Data.msg_datetime, "2019-05-15T08:58:56", out Response)) return BadRequest(Response);

        if (!TestValue("action", Data.action, "mergepatient", out Response)) return BadRequest(Response);


        if (!TestValue("ur_num", Data.ur_num, "1085634", out Response)) return BadRequest(Response);
        if (!TestValue("assigning_authority", Data.assigning_authority, "SAH", out Response)) return BadRequest(Response);

        if (!TestValue("fname", Data.fname, "One Bee", out Response)) return BadRequest(Response);
        if (!TestValue("surname", Data.surname, "Icims", out Response)) return BadRequest(Response);
        if (!TestValue("sex", Data.sex, "M", out Response)) return BadRequest(Response);
        if (!TestValue("dob", Data.dob, "1950-01-01", out Response)) return BadRequest(Response);


        if (!TestValue("addr_line_1", Data.addr_line_1, "1 Brown Street", out Response)) return BadRequest(Response);
        if (!TestValue("addr_line_2", Data.addr_line_2, null, out Response)) return BadRequest(Response);
        if (!TestValue("postcode", Data.postcode, "2076", out Response)) return BadRequest(Response);        
        if (!TestValue("suburb", Data.suburb, "Normanhurst", out Response)) return BadRequest(Response);
        if (!TestValue("state", Data.state, null, out Response)) return BadRequest(Response);

        if (!TestValue("mobile", Data.mobile, null, out Response)) return BadRequest(Response);
        if (!TestValue("phone", Data.phone, "02 99999999", out Response)) return BadRequest(Response);

        if (!TestValue("language", Data.language, null, out Response)) return BadRequest(Response);
        if (!TestValue("marital_status", Data.marital_status, "S", out Response)) return BadRequest(Response);
                       
        if (!TestValue("prior_ur", Data.prior_ur, "1085638", out Response)) return BadRequest(Response);
        if (!TestValue("prior_assigning_authority", Data.prior_assigning_authority, "SAH", out Response)) return BadRequest(Response);
      }

      return Ok(new IcimsResponse() { state = "Ok", error = "No Error" });

    }


    private bool TestValue(string Name, string RecivedValue, string ExpectedValue, out IcimsResponse Response)
    {
      Response = new IcimsResponse();
      if (RecivedValue != ExpectedValue)
      {
        Response.state = "Error";
        Response.error = $"{Name}: '{RecivedValue}' expected '{ExpectedValue}'";
        return false;
      }
      Response = null;
      return true;
    }
  }
}
