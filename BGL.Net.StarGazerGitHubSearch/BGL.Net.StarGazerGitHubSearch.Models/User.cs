using Newtonsoft.Json;
using System.Collections.Generic;

namespace BGL.Net.StarGazerGitHubSearch.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        public string Location { get; set; }

        [JsonProperty("public_repos")]
        public int PublicRepos { get; set; } 

        public List<RepoInformation> RepoList { get; set; }
    }
}