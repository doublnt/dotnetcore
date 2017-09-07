using MiddlewareDemo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestingControllersSample.Tests.IntegrationTests
{
    public class HomeControllerTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public HomeControllerTests(TestFixture<MiddlewareDemo.Startup> fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task WelcomeTest()
        {
            // Act
            var response = await _client.GetAsync("/test");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

        }
    }
}