using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.ThreadSafe
{
    public class HttpWebRequestThreadSafeTest
    {
        private static int _threadCount = 5;

        private static HttpWebRequest CreateHttpWebRequest(int num)
        {
            var url = new Uri("http://www.baidu.com/s?ie=utf-8&f=8&rsv_bp=1&ch=&tn=baiduerr&bar=&wd=" + num);

            var request = WebRequest.Create(url) as HttpWebRequest;
            return request;
        }

        private static string GetHttpWebResponse(HttpWebRequest request)
        {
            var response = request.GetResponse() as HttpWebResponse;

            using (var stream = response?.GetResponseStream())
            {
                if (stream == null)
                {
                    return null;
                }

                var streamReader = new StreamReader(stream);
                var content = streamReader.ReadToEnd();
                return content;
            }

        }

        private static void Do(int num)
        {
            var request = CreateHttpWebRequest(num);
            Console.WriteLine("Current Connections:" + request.ServicePoint.CurrentConnections);
            Console.WriteLine("Current Default connections:" + request.ServicePoint.ConnectionLimit);
            Console.WriteLine("Address：" + request.ServicePoint.Address);
            Console.WriteLine("Connection Group:" + request.ConnectionGroupName);
            var response = GetHttpWebResponse(request);
        }

        public static void TestThreadSafe()
        {
            Task[] tasks = new Task[_threadCount];

            for (int i = 0; i < _threadCount; ++i)
            {
                int temp = i;
                tasks[temp] = Task.Run(() => Do(temp));
            }

            Task.WaitAll(tasks);
        }

        private static void ShowProperties(ServicePoint sp)
        {
            Console.WriteLine("Done calling FindServicePoint()...");

            // Display the ServicePoint Internet resource address.
            Console.WriteLine("Address = {0} ", sp.Address);

            // Display the date and time that the ServicePoint was last 
            // connected to a host.
            Console.WriteLine("IdleSince = " + sp.IdleSince);

            // Display the maximum length of time that the ServicePoint instance  
            // is allowed to maintain an idle connection to an Internet  
            // resource before it is recycled for use in another connection.
            Console.WriteLine("MaxIdleTime = " + sp.MaxIdleTime);

            Console.WriteLine("ConnectionName = " + sp.ConnectionName);

            // Display the maximum number of connections allowed on this 
            // ServicePoint instance.
            Console.WriteLine("ConnectionLimit = " + sp.ConnectionLimit);

            // Display the number of connections associated with this 
            // ServicePoint instance.
            Console.WriteLine("CurrentConnections = " + sp.CurrentConnections);
        }
    }
}
