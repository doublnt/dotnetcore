using System;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncAndAwait
{
    public class AwaitDemo
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private readonly Uri Uri = new Uri("http://www.baidu.com");


        public async Task<string> GetAsync(string id)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
            });

            Console.WriteLine(id);

            return "111";
        }

        public async Task<string> GetAsync2(string id)
        {
            var response = await HttpClient.GetAsync(Uri);

            Console.WriteLine(response.Version.ToString());

            return response.Version.ToString();
        }
    }
}
