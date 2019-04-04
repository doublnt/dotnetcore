using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiddlewareDemo;
using Serilog;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace TestingControllersSample.Tests.IntegrationTests {
    // public class HomeControllerTests : IClassFixture<TestFixture<Startup>>
    public class HomeControllerTests {
        private readonly HttpClient _client;

        private static string LogTemplate = "[{time}] {channel} {level}: '{method} {uri} HTTP/{version}' {code} {cost}ms {MachineName} {ProcessId} {ThreadId}";
        private static string regexPattern = @"{(.*?)}";
        private static IDictionary<string, string> LogMessageValueMap = new Dictionary<string, string> ();

        // public HomeControllerTests(TestFixture<MiddlewareDemo.Startup> fixture)
        // {
        //     _client = fixture.Client;
        // }

        [Fact]
        public void WelcomeTest () {
            // string outputTemplate = "{age} {name} {test}{NewLine} {22}";
            // var logger = new LoggerConfiguration()
            //     .WriteTo.Console(outputTemplate: outputTemplate)
            //     .CreateLogger();

            // object[] value = { "1008", "robert", "test", "invalue" };

            // logger.Information(outputTemplate, value);

            var timeTicksBegin = DateTime.Now.Ticks;
            var timeTickEnd = DateTime.Now.AddMilliseconds (1000).Ticks;
            var timeSpan = new TimeSpan (timeTickEnd - timeTicksBegin);

            var totalSecond = timeSpan.TotalSeconds;

            var path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}