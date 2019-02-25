using Icims.Common.Models.IcimsHttpClientModel;
using Icims.Common.Models.IcimsInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Icims.BusinessLayer
{
  public interface IIcimsHttpClient
  {
    Task<int> GetTester();
    Task<IIcimsHttpClientOutcome> PostAddAsync(IDictionary<string, string> Data);
    Task<IIcimsHttpClientOutcome> PostUpdateAsync(IDictionary<string, string> Data);
    Task<IIcimsHttpClientOutcome> PostMergeAsync(IDictionary<string, string> Data);

  }
}