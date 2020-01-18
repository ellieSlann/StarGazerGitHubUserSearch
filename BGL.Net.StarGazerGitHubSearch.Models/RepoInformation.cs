using Newtonsoft.Json;

namespace BGL.Net.StarGazerGitHubSearch.Models
{
    public class RepoInformation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stargazers_count")]
        public int StargazersCount { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}