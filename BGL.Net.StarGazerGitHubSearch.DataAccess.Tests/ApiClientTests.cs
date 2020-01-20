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
        protected Mock<IHttpClientWrapper> httpClientWrapperMock { get; set; }

        [SetUp]
        public void SetUp()
        {
            httpClientWrapperMock = new Mock<IHttpClientWrapper>();
        }

        [Test]
        public async Task GetUser_With_Valid_SearchUserName_Returns_User()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedHttpResponseMessage(GetStubbedUser());
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
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
            var stubbedResponseMessage = GetStubbedEmptyHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetUser_With_Invalid_HttpResponseMessageContent_Throws_JsonReaderException()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedInvalidHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);

            //Act
            var ex = Assert.ThrowsAsync<JsonReaderException> (() => apiClient.GetUser("robconery"));

            //Assert
            Assert.IsTrue(ex.Message.Contains("Invalid JavaScript property identifier character:"));
        }

        [Test]
        public async Task GetUser_With_Invalid_SearchUserName_Returns_Empty_User()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedNotFoundHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
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
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser(string.Empty);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Valid_SearchUserName_Returns_RepoList()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedHttpResponseMessage(GetStubbedRepoList());
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
            var expected = GetStubbedRepoList();

            //Act
            var actual = await apiClient.GetRepoList("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Empty_HttpResponseMessageContent_Returns_Empty_RepoList()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedEmptyHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Invalid_HttpResponseMessageContent_Throws_JsonReaderException()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedInvalidHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);

            //Act
            var ex = Assert.ThrowsAsync<JsonReaderException>(() => apiClient.GetUser("robconery"));

            //Assert
            Assert.IsTrue(ex.Message.Contains("Invalid JavaScript property identifier character:"));
        }

        [Test]
        public async Task GetRepoList_With_Invalid_SearchUserName_Returns_Empty_RepoList()
        {
            //Arrange
            var stubbedResponseMessage = GetStubbedNotFoundHttpResponseMessage();
            var httpClientWrapper = await SetUpMockHttpClientWrapperAsync(stubbedResponseMessage);
            var apiClient = new ApiClient(httpClientWrapper.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task GetRepoList_With_Empty_SearchUSerName_Returns_Empty_RepoList()
        {
            //Arrange
            var apiClient = new ApiClient(httpClientWrapperMock.Object);
            var expected = new User();

            //Act
            var actual = await apiClient.GetUser(string.Empty);

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        private static User GetStubbedUser()
        {
            return new User
            {
                AvatarUrl = "https://avatars0.githubusercontent.com/u/78586?v=4",
                Followers = 1582,
                Following = 0,
                Location = "Honolulu, HI",
                Name = "Rob Conery",
                PublicRepos = 43,
                RepoList = null
            };
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

        private async Task<HttpResponseMessage> GetStubbedHttpResponseMessage(object stubbedObject)
        {
            var httpResponseMessage = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(stubbedObject)),
                StatusCode = HttpStatusCode.OK
            };

            return await Task.FromResult(httpResponseMessage);
        }

        private async Task<Mock<IHttpClientWrapper>> SetUpMockHttpClientWrapperAsync(Task<HttpResponseMessage> stubbedResponseMessage)
        {
            httpClientWrapperMock.Setup(x => x.GetAsync(It.IsAny<Uri>(),
                It.IsAny<HttpRequestMessage>())).Returns(stubbedResponseMessage);
            return httpClientWrapperMock;
        }
    }
}
