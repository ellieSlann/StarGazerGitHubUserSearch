using BGL.Net.StarGazerGitHubSearch.Models;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch
{
    public interface IUserModelBuilder
    {
        Task<User> Build(string searchUserName);
    }
}
