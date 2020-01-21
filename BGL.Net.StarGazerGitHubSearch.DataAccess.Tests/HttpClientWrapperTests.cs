using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace BGL.Net.StarGazerGitHubSearch.DataAccess.Tests
{
    [TestFixture]
    public class HttpClientWrapperTests
    {
        private static HttpClientWrapper httpClientWrapper;

        [SetUp]
        public void SetUp()
        {
            httpClientWrapper = new HttpClientWrapper();
        }

        [Test]
        public async Task GetAsyncWithValidParametersShouldReturnTaskOfHttpResponseMessage()
        {
            var uri = new Uri( "https://api.github.com/users/robconery/repos");
            var requestMessage = new HttpRequestMessage();

            var response = await httpClientWrapper.GetAsync(uri, requestMessage);

            Assert.That(response.IsSuccessStatusCode);
        }

        [Test]
        public void GetAsyncShouldCatchException()
        {
            //to do: implement test - need to work out how to recreate an exception for this
        }
    }
}
