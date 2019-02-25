using Icims.Common.Models.IcimsHttpClientModel;
using Icims.Common.Models.IcimsInterface;
using System.Threading.Tasks;

namespace Icims.BusinessLayer
{
  public interface IIcimsHttpClient
  {
    Task<int> GetTester();
    Task<IIcimsHttpClientOutcome> PostAddAsync(IValueDictionary Data);
    Task<IIcimsHttpClientOutcome> PostUpdateAsync(IValueDictionary Data);
    Task<IIcimsHttpClientOutcome> PostMergeAsync(IValueDictionary Data);

  }
}