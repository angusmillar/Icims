using Icims.Common.Models.AppSettings;
using Icims.Common.Models.IcimsHttpClientModel;
using Icims.Common.Models.IcimsInterface;
using Icims.Common.Tools;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Icims.BusinessLayer
{
  public class IcimsHttpClient : IIcimsHttpClient
  {
    private readonly HttpClient HttpClient;
    private enum SendActionType
    {
      [EnumLiteral("add")]
      Add,
      [EnumLiteral("update")]
      Update,
      [EnumLiteral("merge")]
      Merge
    }

    public IcimsHttpClient(IOptions<IcimsSiteContext> IcimsSiteContext, HttpClient client)
    {
      HttpClient = client;
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

    public async Task<IIcimsHttpClientOutcome> PostAddAsync(IValueDictionary Data)
    {
      return await PostAsync(SendActionType.Add, Data);
    }

    public async Task<IIcimsHttpClientOutcome> PostUpdateAsync(IValueDictionary Data)
    {
      return await PostAsync(SendActionType.Update, Data);
    }

    public async Task<IIcimsHttpClientOutcome> PostMergeAsync(IValueDictionary Data)
    {
      return await PostAsync(SendActionType.Merge, Data);
    }

    private async Task<IIcimsHttpClientOutcome> PostAsync(SendActionType ActionType, IValueDictionary Data)
    {
      var DataDictionary = Data.GetValueDictionary();
      var EncodedData = new FormUrlEncodedContent(DataDictionary);
      var HttpResponse = await HttpClient.PostAsync(ActionType.GetLiteral(), EncodedData);
      var Outcome = new IcimsHttpClientOutcome();
      Outcome.HttpStatusCode = HttpResponse.StatusCode;
      var jsonString = await HttpResponse.Content.ReadAsStringAsync();
      Outcome.IcimsResponse = JsonConvert.DeserializeObject<IcimsResponse>(jsonString);
      return Outcome;
    }

  }
}
