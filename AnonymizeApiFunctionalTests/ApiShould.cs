using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AnonymizeApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.WebUtilities;
using Xunit;

namespace AnonymizeApiFunctionalTests
{
    public class ApiShould
    {
        private readonly HttpClient _httpClient;

        public ApiShould()
        {
            var testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _httpClient = testServer.CreateClient();
        }

        [Fact]
        public async Task ReturnSuccessFromHealthRoute()
        {
            var responseText = await _httpClient.GetStringAsync("/health");

            Assert.Equal("Success", responseText);
        }

        [Fact]
        public async Task ReturnHtmlFromSomethingRoute()
        {
            var queryParameters = new Dictionary<string, string> {{"url", "https://www.directsupply.com/stories/"}};

            var url = QueryHelpers.AddQueryString("/anonymize", queryParameters);

            var responseText = await _httpClient.GetStringAsync(url);

            Assert.NotEmpty(responseText);
        }
    }
}