using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private static HttpClient _httpClient;
        private const string GITHUBUSERAGENT = "GitHubCall";
        private const string GITHUBMEDIATYPE = "application/vnd.github.v3+json";

        public HttpClientWrapper()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Add("User-Agent", GITHUBUSERAGENT);
                _httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue(GITHUBMEDIATYPE));
            }
        }

        public async Task<HttpResponseMessage> GetAsync(Uri uri, HttpRequestMessage requestMessage)
        {
            requestMessage.Method = HttpMethod.Get;
            requestMessage.RequestUri = uri;

            try
            {
                var clientResponse = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                return clientResponse;
            }
            catch (Exception e)
            {
                throw new Exception("HttpRequest failed", e);
            }
        }
    }
}
