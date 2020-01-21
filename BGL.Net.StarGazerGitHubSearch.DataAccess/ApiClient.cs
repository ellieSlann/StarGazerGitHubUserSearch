using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BGL.Net.StarGazerGitHubSearch.Models;
using Newtonsoft.Json;
using System.Linq;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess
{
    public class ApiClient : IApiClient
    {
        private readonly IHttpClientWrapper _wrapper;
        public const string GITHUBAPI = "https://api.github.com/users/";


        public ApiClient(IHttpClientWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public async Task<List<RepoInformation>> GetRepoList(string searchUserName)
        {
            var uri = new Uri(GITHUBAPI + searchUserName + "/repos");

            var responseMessage = await GetResponseMessage(uri);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            var repos = JsonConvert.DeserializeObject<List<RepoInformation>>(responseContent.ToString());
            var topFiveRepos = GetTopFiveRepos(repos);
            return topFiveRepos;
        }

        public async Task<User> GetUser(string searchUserName)
        {
            if (string.IsNullOrWhiteSpace(searchUserName))
            {
                return new User();
            }
            var uri = new Uri(GITHUBAPI + searchUserName);

            var responseMessage = await GetResponseMessage(uri);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseContent.ToString());
                return user;
            }
            return new User();
        }

        private static List<RepoInformation> GetTopFiveRepos(List<RepoInformation> repos)
        {
            var orderedRepoList = from r in repos
                                  orderby r.StargazersCount descending
                                  select r;

            return orderedRepoList.Take(5).ToList();
        }

        private async Task<HttpResponseMessage> GetResponseMessage(Uri uri)
        {
            var httpRequestMessage = new HttpRequestMessage();
            return await _wrapper.GetAsync(uri, httpRequestMessage).ConfigureAwait(false);
        }

 
    }
}
