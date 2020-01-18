using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess
{
    public interface IHttpClientWrapper
    {
        Task<HttpResponseMessage> GetAsync(Uri uri, HttpRequestMessage requestMessage);
    }
}