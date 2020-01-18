using System.Net.Http;
using System.Net.Http.Headers;


namespace BGL.Net.StarGazerGitHubSearch.Utilities
{
    public class HttpClientBuilder : IHttpClientBuilder
    {
        private const string GITHUBUSERAGENT = "GitHubCall";
        private const string GITHUBMEDIATYPE = "application/vnd.github.v3+json";

        public HttpClient BuildHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", GITHUBUSERAGENT);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(GITHUBMEDIATYPE));
            return client;
        }
    }
}