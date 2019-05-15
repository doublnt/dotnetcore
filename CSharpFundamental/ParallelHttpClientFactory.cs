using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class ParallelHttpClientFactory
    {
        private HttpClient _httpClient = new HttpClient();

        public async Task DoParallelThing()
        {
            for (int i = 0; i < 1000; i++)
            {
                await Task.Run(async () => await GetPostResult());

            }
            //            ThreadPool.QueueUserWorkItem(DoThing, 10000);
        }

        public async void DoThing(Object stats)
        {
            await GetPostResult();
        }

        private async Task<String> GetPostResult()
        {
            var url = "https://www.baidu.com";
            var stringContent = new StringContent("Test String Content");

            var rlt = await _httpClient.PostAsync(url, stringContent);
            var bts = await rlt.Content.ReadAsByteArrayAsync();

            Console.WriteLine(Encoding.UTF8.GetString(bts));

            return Encoding.UTF8.GetString(bts);
        }
    }
}
