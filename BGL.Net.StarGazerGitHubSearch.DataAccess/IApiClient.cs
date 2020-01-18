using BGL.Net.StarGazerGitHubSearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess
{
    public interface IApiClient
    {
        Task<User> GetUser(string searchUserName);
        Task<List<RepoInformation>> GetRepoList(string searchUserName);
    }
}