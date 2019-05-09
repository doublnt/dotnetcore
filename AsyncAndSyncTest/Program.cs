using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAndSyncTest
{
    class Program
    {
        /// <summary>
        /// C# 7.1 feature async Main Function
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var value1 = GetWebStringCount();
            Console.WriteLine(value1);

            var value2 = await GetWebStringCountAsync();
            Console.WriteLine(value2);

            //Deadlock code
            //            var deaklock = new Deadlock();
            //            await deaklock.GetResponseValue();
            //
            //            Console.WriteLine(await deaklock.GetResponseValue());

            Marshalling();
        }

        static async Task<string> GetWebStringCountAsync()
        {
            //            Stopwatch watch = new Stopwatch();
            //            watch.Start();
            //            var request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
            //            var response = (HttpWebResponse)await request.GetResponseAsync();
            //            watch.Stop();
            //            Console.WriteLine("The Async Current execute Time is(ms):" + watch.ElapsedMilliseconds);
            //
            //            return response.StatusCode.ToString();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var task = Task.Run(async () =>
            {
                var request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
                var response = (HttpWebResponse)await request.GetResponseAsync();
                return response.StatusCode.ToString();
            });
            watch.Stop();
            Console.WriteLine("The Async Current execute Time is(ms):" + watch.ElapsedMilliseconds);
            Console.WriteLine(System.Environment.CurrentManagedThreadId);

            return await task;
        }

        static string GetWebStringCount()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var request = (HttpWebRequest)WebRequest.Create("https://www.baidu.com");
            var response = (HttpWebResponse)request.GetResponse();
            watch.Stop();
            Console.WriteLine("The Sync Current execute Time is(ms):" + watch.ElapsedMilliseconds);
            Console.WriteLine(System.Environment.CurrentManagedThreadId);

            return response.StatusCode.ToString();
        }

        private static void Marshalling()
        {
            AppDomain adCallingDomainName = Thread.GetDomain();

            String callingDomainName = adCallingDomainName.FriendlyName;
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            String exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main Assembly={0}", exeAssembly);

            AppDomain ad2 = null;
            Console.WriteLine("{0} DEMO#1", Environment.NewLine);

            ad2 = AppDomain.CreateDomain("AD #2");
            MarshalByRefObject mbrt = null;

            AppDomain.Unload(ad2);
        }
    }
}
