using Icims.Common.Models.AppSettings;
using Icims.Common.Models.IcimsHttpClientModel;
using Icims.Common.Models.IcimsInterface;
using Icims.Common.Tools;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Icims.Common.Models.BusinessModel;

namespace Icims.BusinessLayer
{
  public class IcimsHttpClient : IIcimsHttpClient
  {
    private readonly HttpClient HttpClient;
    private readonly IOptions<IcimsSiteContext> IcimsSiteContext;
    
    public IcimsHttpClient(IOptions<IcimsSiteContext> IcimsSiteContext, HttpClient client)
    {
      HttpClient = client;
      this.IcimsSiteContext = IcimsSiteContext;
      HttpClient.BaseAddress = new Uri(IcimsSiteContext.Value.Endpoint);
      //HttpClient.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
      HttpClient.DefaultRequestHeaders.Add("User-Agent", IcimsSiteContext.Value.NameOfThisService);
      HttpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
      HttpClient.DefaultRequestHeaders.Add("Accept", "*/*");
      HttpClient.DefaultRequestHeaders.Add("Authorization", IcimsSiteContext.Value.AuthorizationToken);
    }

    public async Task<int> GetTester()
    {
      var data = await HttpClient.GetStringAsync("/add");
      return data.Length;
    }

    public async Task<IIcimsHttpClientOutcome> PostAddAsync(IDictionary<string, string> Data)
    {
      return await PostAsync(PostActionType.Add, Data);
    }

    public async Task<IIcimsHttpClientOutcome> PostUpdateAsync(IDictionary<string, string> Data)
    {      
      return await PostAsync(PostActionType.Update, Data);
    }

    public async Task<IIcimsHttpClientOutcome> PostMergeAsync(IDictionary<string, string> Data)
    {
      return await PostAsync(PostActionType.Merge, Data);
    }

    private async Task<IIcimsHttpClientOutcome> PostAsync(PostActionType ActionType, IDictionary<string, string> Data)
    {
      var Outcome = new IcimsHttpClientOutcome();      
      var EncodedData = new FormUrlEncodedContent(Data);
      try
      {
        var HttpResponse = await HttpClient.PostAsync(ActionType.GetLiteral(), EncodedData);
       
        Outcome.HttpStatusCode = HttpResponse.StatusCode;
        var jsonString = await HttpResponse.Content.ReadAsStringAsync();
        Outcome.Message = "Icims Response Received";
        Outcome.IcimsResponse = JsonConvert.DeserializeObject<IcimsResponse>(jsonString);
        return Outcome;
      }
      catch(HttpRequestException HttpRequestException)
      {
        Outcome.HttpStatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        Outcome.Message = $"Unable to contact Icims on Endpoint: {IcimsSiteContext.Value.Endpoint} for Action: {ActionType.GetLiteral()}. HttpRequestException Message: {HttpRequestException.Message}";
        Outcome.IcimsResponse = null;
        return Outcome;
      }
      catch(Exception exec)
      {
        Outcome.HttpStatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        Outcome.Message = $"Unable to contact Icims on Endpoint: {IcimsSiteContext.Value.Endpoint} for Action: {ActionType.GetLiteral()}. Exception Message: {exec.Message}";
        Outcome.IcimsResponse = null;
        return Outcome;
      }
    }

  }
}
