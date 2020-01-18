using System.Net.Http;

namespace BGL.Net.StarGazerGitHubSearch.Utilities
{
    public interface IHttpClientBuilder
    {
        HttpClient BuildHttpClient();
    }
}
