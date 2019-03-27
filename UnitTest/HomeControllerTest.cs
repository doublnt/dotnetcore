using MiddlewareDemo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace TestingControllersSample.Tests.IntegrationTests
{
    // public class HomeControllerTests : IClassFixture<TestFixture<Startup>>
    public class HomeControllerTests
    {
        private readonly HttpClient _client;

        private static string LogTemplate = "[{time}] {channel} {level}: '{method} {uri} HTTP/{version}' {code} {cost}ms {MachineName} {ProcessId} {ThreadId}";
        private static string regexPattern = @"{(.*?)}";
        private static IDictionary<string, string> LogMessageValueMap = new Dictionary<string, string>();

        // public HomeControllerTests(TestFixture<MiddlewareDemo.Startup> fixture)
        // {
        //     _client = fixture.Client;
        // }

        [Fact]
        public void WelcomeTest()
        {
            Regex re = new Regex(regexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var matches = re.Matches(LogTemplate);

            if (0 < matches.Count)
            {
                foreach (Match item in matches)
                {
                    LogMessageValueMap.Add
                }
            }
        }
    }
}