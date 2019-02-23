using Microsoft.VisualStudio.TestTools.UnitTesting;
using Icims.Common.Models.BusinessEngine;
using Icims.BusinessLayer;
using System.Text;
using Microsoft.Extensions.Options;
using Icims.Common.Models.AppSettings;
using System.Threading.Tasks;

namespace Icims.Test
{
  [TestClass]
  public class BusinessEngine_Test
  {
    [TestMethod]
    public void Process_Ok()
    {
      //Prepaid            
      var Input = new Moq.Mock<IBusinessEngineInput>();
      string HL7Message = GetTestMessage("RMH_ADT_A08");
      Input.Setup(x => x.HL7V2Message).Returns(HL7Message);

      IOptions<IcimsSiteContext> IcimsSiteContextOptions = Options.Create(new IcimsSiteContext()
      {
        AuthorizationToken = "none",
        Endpoint = "http://localhost:8888/fhir/Patient/_search",
        NameOfThisService = "Icims Proxy Service Testing",
        PrimaryMRNAssigningAuthorityCode = "RMH"
      });

      var DummyHttpClient = new IcimsHttpClient(IcimsSiteContextOptions, new System.Net.Http.HttpClient());

      //var HttpClient = new Moq.Mock<IIcimsHttpClient>();
      //HttpClient.Setup(x => x.GetTester()).Returns(Task.FromResult(1000));


      var BusinessEngine = new BusinessEngine(IcimsSiteContextOptions, new BusinessEngineOutcome(), new IcimsInterfaceModelMapper(), DummyHttpClient);

      //Act
      var Result = BusinessEngine.Process(Input.Object);

      //Assert
      Assert.IsTrue(Result.Success, "Process did not return Success = True");
      Assert.AreEqual("OK", Result.ErrorMessage, "ErrorMessage was not 'OK'");
    }

    private string GetTestMessage(string FileName)
    {
      var HL7MessageStream = (byte[])Resource.ResourceManager.GetObject(FileName);
      return Encoding.UTF8.GetString(HL7MessageStream).Replace("\r\n", "\r");      
    }
  }
}
