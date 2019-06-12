using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncAndAwait
{
    public class AsyncDemo
    {
        private string url = "https://aliyun.com";

        public async Task<string> GetValue()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> fetchText = httpClient.GetStringAsync(url);

                var value = await fetchText;
                return value.Length.ToString();
            }
        }

        public async Task ThrowExcpetionMethod()
        {
            var value = ParseWithNullValue(null);

            // If current does not await the value, it will be execute continue.
            await value;

            Console.WriteLine("test");
            Console.WriteLine(value.GetType());
        }

        private async Task<string> ParseWithNullValue(string args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(args);
            }

            using (var httpClient = new HttpClient())
            {
                var value = await httpClient.GetStringAsync(new Uri("https://aliyun.com"));

                return value;
            }
        }
    }
}
