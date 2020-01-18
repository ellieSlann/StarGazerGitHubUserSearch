using BGL.Net.StarGazerGitHubSearch.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess.Tests
{
    [TestFixture]
    public class ApiClientTests
    {
        [Test]
        public async void GetUser_With_Valid_SearchUserName_Returns_User()
        {
            //Arrange
            var httpClientWrapperMock = new Mock<IHttpClientWrapper>();
            var apiClient = new ApiClient(httpClientWrapperMock.Object);


            //Act
            var actual = await apiClient.GetUser("robconery");

            //Assert

        }

        private User GetFakeUser()
        {
            return new User {
                AvatarUrl = "",
                Followers = 0,
                Following = 0,
                Location = "",
                Name = "",
                PublicRepos = 0,
                RepoList = new List<RepoInformation>()
            };
        }
    }
}
