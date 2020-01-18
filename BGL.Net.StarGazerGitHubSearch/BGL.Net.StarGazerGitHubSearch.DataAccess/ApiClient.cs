using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BGL.Net.StarGazerGitHubSearch.Models;
using Newtonsoft.Json;

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
            var httpRequestMessage = new HttpRequestMessage();
            List<RepoInformation> repos = null;

            try
            {
                var responseMessage = await _wrapper.GetAsync(uri, httpRequestMessage).ConfigureAwait(false);
                repos = JsonConvert.DeserializeObject<List<RepoInformation>>(responseMessage.ToString());
            }
            catch
            {
            }

            return repos;
        }

        public async Task<User> GetUser(string searchUserName)
        {
            var uri = new Uri(GITHUBAPI + searchUserName);
            var httpRequestMessage = new HttpRequestMessage();
            User user = null;

            try
            {
               var responseMessage = await _wrapper.GetAsync(uri, httpRequestMessage).ConfigureAwait(false);
              // user = JsonConvert.DeserializeObject<List<User>>(responseMessage.ToString());
            }
            catch
            {

            }

            return user;
        }

        public async Task<HttpResponseMessage> GetUserAsync(string searchUserName)
        {
            HttpResponseMessage responseMessage = null;

            var uri = new Uri(GITHUBAPI + searchUserName);
            var httpRequestMessage = new HttpRequestMessage();

            try
            {
                responseMessage = await _wrapper.GetAsync(uri, httpRequestMessage).ConfigureAwait(false);
            }
            catch
            {

            }

            return responseMessage;
        }
    }
}
