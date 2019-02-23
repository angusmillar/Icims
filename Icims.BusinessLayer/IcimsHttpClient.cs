using Icims.Common.Models.AppSettings;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Icims.Common.Tools;
using Icims.Common.Models.IcimsInterface;

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
    
    public async Task<bool> PostAddAsync(IValueDictionary Data)
    {     
      return await PostAsync(SendActionType.Add, Data);      
    }

    public async Task<bool> PostUpdateAsync(IValueDictionary Data)
    {
      return await PostAsync(SendActionType.Update, Data);      
    }

    public async Task<bool> PostMergeAsync(IValueDictionary Data)
    {
      return await PostAsync(SendActionType.Merge, Data);      
    }

    private async Task<bool> PostAsync(SendActionType ActionType, IValueDictionary Data)
    {
      var DataDictionary = Data.GetValueDictionary();
      var EncodedData = new FormUrlEncodedContent(DataDictionary);
      var data = await HttpClient.PostAsync(ActionType.GetLiteral(), EncodedData);
      return data.IsSuccessStatusCode;
    }

  }
}
