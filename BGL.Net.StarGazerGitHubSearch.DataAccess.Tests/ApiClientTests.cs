using BGL.Net.StarGazerGitHubSearch.Models;
using FluentAssertions;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess.Tests
{
    [TestFixture]
    public class ApiClientTests
    {
        [Test]
        public async Task GetUser_With_Valid_SearchUserName_Returns_User()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetStubbedHttpResponseMessage());
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = GetStubbedUser();
            
            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetUser_With_Empty_HttpResponseMessageContent_Returns_Empty_User()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetStubbedEmptyHttpResponseMessage());
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetUser_With_Invalid_HttpResponseMessageContent_Throws_JsonReaderException()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetStubbedInvalidHttpResponseMessage());
            var apiClient = new ApiClient(httpClientWrapperMock.Object);

            //Act
            var ex = Assert.ThrowsAsync<JsonReaderException> (() => apiClient.GetUser("robconery"));

            //Assert
            Assert.IsTrue(ex.Message.Contains("Invalid JavaScript property identifier character:"));
        }

        [Test]
        public async Task GetUser_With_Invalid_SearchUserName_Returns_Empty_User()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetStubbedNotFoundHttpResponseMessage());
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetUser_With_Empty_SearchUserName_Returns_Empty_User()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser(string.Empty);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        private static User GetStubbedUser()
        {
            return new User {
                AvatarUrl = "https://avatars0.githubusercontent.com/u/78586?v=4",
                Followers = 1582,
                Following = 0,
                Location = "Honolulu, HI",
                Name = "Rob Conery",
                PublicRepos = 43,
                RepoList = null
            };
        }

        [Test]
        public async Task GetRepoList_With_Valid_SearchUserName_Returns_RepoList()
        {
            ////Arrange
            //var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            //httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetFakeHttpResponseMessage());
            //var apiClient = new ApiClient(httpClientWrapperMock.Object);
            //var expected = GetFakeRepoList();

            ////Act
            //var actual = await apiClient.GetRepoList("robconery");

            ////Assert
            //actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Empty_HttpResponseMessageContent_Returns_Empty_RepoList()
        {
            ////Arrange
            //var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            //httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetFakeEmptyHttpResponseMessage());
            //var apiClient = new ApiClient(httpClientWrapperMock.Object);
            //var expected = new User();

            ////Act
            //var actual = await apiClient.GetUser("robconery");

            ////Assert
            //actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void GetRepoList_With_Invalid_HttpResponseMessageContent_Throws_JsonReaderException()
        {
            ////Arrange
            //var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            //httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetFakeInvalidHttpResponseMessage());
            //var apiClient = new ApiClient(httpClientWrapperMock.Object);

            ////Act
            //var ex = Assert.ThrowsAsync<JsonReaderException>(() => apiClient.GetUser("robconery"));

            ////Assert
            //Assert.IsTrue(ex.Message.Contains("Invalid JavaScript property identifier character:"));
        }

        [Test]
        public async Task GetRepoList_With_Invalid_SearchUserName_Returns_Empty_RepoList()
        {
            ////Arrange
            //var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            //httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(), It.IsAny<HttpRequestMessage>())).Returns(GetFakeNotFoundHttpResponseMessage());
            //var apiClient = new ApiClient(httpClientWrapperMock.Object);
            //var expected = new User();

            ////Act
            //var actual = await apiClient.GetUser("robconery");

            ////Assert
            //actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Empty_SearchUSerName_Returns_Empty_RepoList()
        {
            //Arrange
            //var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            //var apiClient = new ApiClient(httpClientWrapperMock.Object);
            //var expected = new User();

            ////Act
            //var actual = await apiClient.GetUser(string.Empty);

            ////Assert
            //actual.Should().BeEquivalentTo(expected);
        }

        private static List<RepoInformation> GetStubbedRepoList()
        {
            var repoList = new List<RepoInformation>()
            {
                new RepoInformation
                {
                    Id = 148253985,
                    Description = "",
                    Name = "azure-docs",
                    StargazersCount = 0
                },

                new RepoInformation
                {
                    Id = 11851901,
                    Description = "Capistrano recipes for building a Rails 3/Nginx/Unicorn/Postgres/Memcached/Redis server, inspired by Railscasts",
                    Name = "capistrano-rails-server",
                    StargazersCount = 2
                },

                new RepoInformation
                {
                    Id = 45650038,
                    Description = "Comments done simple",
                    Name = "commented",
                    StargazersCount = 1
                }
            };
            
            return repoList;
        }

        //public static RepoInformation Id { get; set; }

        private async Task<HttpResponseMessage> GetStubbedNotFoundHttpResponseMessage()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotFound
            };

            return await Task.FromResult(httpResponseMessage);
        }

        private async Task<HttpResponseMessage> GetStubbedEmptyHttpResponseMessage()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("{}"),
                StatusCode = HttpStatusCode.OK
            };

            return await Task.FromResult(httpResponseMessage);
        }

        private async Task<HttpResponseMessage> GetStubbedInvalidHttpResponseMessage()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent("{d}"),
                StatusCode = HttpStatusCode.OK
            };

            return await Task.FromResult(httpResponseMessage);
        }

        private async Task<HttpResponseMessage> GetStubbedHttpResponseMessage()
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(
                    "{\"login\":\"robconery\",\"id\":78586,\"node_id\":\"MDQ6VXNlcjc4NTg2\",\"avatar_url\":\"https://avatars0.githubusercontent.com/u/78586?v=4\",\"gravatar_id\":\"\",\"url\":\"https://api.github.com/users/robconery\",\"html_url\":\"https://github.com/robconery\",\"followers_url\":\"https://api.github.com/users/robconery/followers\",\"following_url\":\"https://api.github.com/users/robconery/following{/other_user}\",\"gists_url\":\"https://api.github.com/users/robconery/gists{/gist_id}\",\"starred_url\":\"https://api.github.com/users/robconery/starred{/owner}{/repo}\",\"subscriptions_url\":\"https://api.github.com/users/robconery/subscriptions\",\"organizations_url\":\"https://api.github.com/users/robconery/orgs\",\"repos_url\":\"https://api.github.com/users/robconery/repos\",\"events_url\":\"https://api.github.com/users/robconery/events{/privacy}\",\"received_events_url\":\"https://api.github.com/users/robconery/received_events\",\"type\":\"User\",\"site_admin\":false,\"name\":\"Rob Conery\",\"company\":\"BigMachine\",\"blog\":\"http://rob.conery.io\",\"location\":\"Honolulu, HI\",\"email\":null,\"hireable\":null,\"bio\":\"I am the author of The Imposter's Handbook, founder of Big Machine, and a Senior Cloud Developer Engineer at Microsoft. I also host and produce a few podcasts.\",\"public_repos\":43,\"public_gists\":35,\"followers\":1582,\"following\":0,\"created_at\":\"2009-04-28T02:08:55Z\",\"updated_at\":\"2018-10-18T00:00:53Z\"}"),
                StatusCode = HttpStatusCode.OK
            };

            return await Task.FromResult(httpResponseMessage);
        }
    }
}
