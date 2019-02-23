using Icims.Common.Models.IcimsInterface;
using System.Net.Http;
using System.Threading.Tasks;

namespace Icims.BusinessLayer
{
  public interface IIcimsHttpClient
  {
    Task<int> GetTester();
    Task<bool> PostAddAsync(IValueDictionary Data);
    Task<bool> PostUpdateAsync(IValueDictionary Data);
    Task<bool> PostMergeAsync(IValueDictionary Data);

  }
}