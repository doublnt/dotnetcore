using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncAndAwait
{
    public class AwaitDemo
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly Uri Uri = new Uri("http://www.baidu.com");

        public async Task<string> GetResponse()
        {
            var response = await HttpClient.GetAsync(Uri);

            return response.Version.ToString();
        }
    }
}
