using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAndSyncTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var value1 = GetWebStringCount();

            var value2 = await GetWebStringCountAsync();
        }

        static async Task<string> GetWebStringCountAsync()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
            var response = (HttpWebResponse)await request.GetResponseAsync();
            watch.Stop();
            Console.WriteLine("The Async Current execute Time is:" + watch.ElapsedMilliseconds);

            return response.StatusCode.ToString();
        }

        static string GetWebStringCount()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
            var response = (HttpWebResponse)request.GetResponse();
            watch.Stop();
            Console.WriteLine("The Sync Current execute Time is:" + watch.ElapsedMilliseconds);

            return response.StatusCode.ToString();
        }
    }
}
