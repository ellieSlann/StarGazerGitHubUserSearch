using BGL.Net.StarGazerGitHubSearch.DataAccess;
using BGL.Net.StarGazerGitHubSearch.Models;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch
{
    public class UserModelBuilder : IUserModelBuilder
    {
        private IApiClient _apiClient;
        
        public UserModelBuilder(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<User> Build(string searchUserName)
        {
            var user = await _apiClient.GetUser(searchUserName);
            user.RepoList = await _apiClient.GetRepoList(searchUserName);
            return user;
        }
    }
}