using Icims.BusinessLayer;
using Icims.Common.Models.AppSettings;
using Icims.Common.Models.BusinessEngine;
using Icims.Common.Models.BusinessModel;
using Icims.Common.Models.IcimsHttpClientModel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Icims.Test
{
  [TestClass]
  public class BusinessEngine_Test
  {

    private IOptions<IcimsSiteContext> BuldOptions()
    {
      return Options.Create(new IcimsSiteContext()
      {
        AuthorizationToken = "none",
        Endpoint = "http://localhost:60823/api/mock/",
        NameOfThisService = "Icims Proxy Service Testing",
        PrimaryMRNAssigningAuthorityCode = "RMH"
      });

    }

    private Moq.Mock<IBusinessEngineInput> BuildBusinessEngineInput(string HL7MessageFile)
    {
      var Input = new Moq.Mock<IBusinessEngineInput>();
      string HL7Message = GetTestMessage(HL7MessageFile);
      Input.Setup(x => x.HL7V2Message).Returns(HL7Message);
      return Input;
    }

    private Moq.Mock<ILogger<BusinessEngine>> BuildLogger()
    {
      var LoggerMok = new Moq.Mock<ILogger<BusinessEngine>>();      
      return LoggerMok;
    }


    private string GetTestMessage(string FileName)
    {
      var HL7MessageStream = (byte[])Resource.ResourceManager.GetObject(FileName);
      return Encoding.UTF8.GetString(HL7MessageStream).Replace("\r\n", "\r");
    }

    [TestMethod]
    public void Add_OK_Intergration_Test()
    {
      //Prepaid            
      Moq.Mock<IBusinessEngineInput> EngineInputMok = BuildBusinessEngineInput("RMH_ADT_A04");
      IOptions<IcimsSiteContext> IcimsSiteContextOptions = BuldOptions();
      var DummyHttpClient = new IcimsHttpClient(IcimsSiteContextOptions, new System.Net.Http.HttpClient());
      
      var BusinessEngine = new BusinessEngine(IcimsSiteContextOptions, new BusinessEngineOutcome(), new IcimsInterfaceModelMapper(), DummyHttpClient, BuildLogger().Object);

      //Act
      var Result = BusinessEngine.Process(EngineInputMok.Object);

      //Assert
      Assert.AreEqual(Result.StatusCode, StatusCode.ok, "Process did not return Success = True");
      Assert.IsTrue(Result.HasIcimsResponse, "HasIcimsResponse did not match expected");
      Assert.AreEqual("Icims Response Received", Result.Message, "Message did not match expected");
      Assert.AreEqual("No Error", Result.IcimsResponse.error, "error Message did not match expected");
      Assert.AreEqual("Ok", Result.IcimsResponse.state, "state did not match expected");
    }
    
    [TestMethod]
    public void Update_OK_Intergration_Test()
    {              
      //Prepaid            
      Moq.Mock<IBusinessEngineInput> EngineInputMok = BuildBusinessEngineInput("RMH_ADT_A08");
      IOptions<IcimsSiteContext> IcimsSiteContextOptions = BuldOptions();
      var DummyHttpClient = new IcimsHttpClient(IcimsSiteContextOptions, new System.Net.Http.HttpClient());     

      var BusinessEngine = new BusinessEngine(IcimsSiteContextOptions, new BusinessEngineOutcome(), new IcimsInterfaceModelMapper(), DummyHttpClient, BuildLogger().Object);

      //Act
      var Result = BusinessEngine.Process(EngineInputMok.Object);

      //Assert
      Assert.AreEqual(Result.StatusCode, StatusCode.ok, "Process did not return Success = True");
      Assert.IsTrue(Result.HasIcimsResponse, "HasIcimsResponse did not match expected");
      Assert.AreEqual("Icims Response Received", Result.Message, "Message did not match expected");
      Assert.AreEqual("No Error", Result.IcimsResponse.error, "error Message did not match expected");
      Assert.AreEqual("Ok", Result.IcimsResponse.state, "state did not match expected");
    }

    [TestMethod]
    public void Merge_OK_Intergration_Test()
    {
      //Prepaid            
      Moq.Mock<IBusinessEngineInput> EngineInputMok = BuildBusinessEngineInput("RMH_ADT_A40");
      IOptions<IcimsSiteContext> IcimsSiteContextOptions = BuldOptions();
      var DummyHttpClient = new IcimsHttpClient(IcimsSiteContextOptions, new System.Net.Http.HttpClient());

      var BusinessEngine = new BusinessEngine(IcimsSiteContextOptions, new BusinessEngineOutcome(), new IcimsInterfaceModelMapper(), DummyHttpClient, BuildLogger().Object);

      //Act
      var Result = BusinessEngine.Process(EngineInputMok.Object);

      //Assert
      Assert.AreEqual(Result.StatusCode, StatusCode.ok, "Process did not return Success = True");
      Assert.IsTrue(Result.HasIcimsResponse, "HasIcimsResponse did not match expected");
      Assert.AreEqual("Icims Response Received", Result.Message, "Message did not match expected");
      Assert.AreEqual("No Error", Result.IcimsResponse.error, "error Message did not match expected");
      Assert.AreEqual("Ok", Result.IcimsResponse.state, "state did not match expected");
    }


  }
}
