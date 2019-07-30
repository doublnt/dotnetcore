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
        private int _threadCount = 10;

        private HttpWebRequest CreateHttpWebRequest()
        {
            var url = new Uri("http://www.baidu.com");

            var request = WebRequest.Create(url) as HttpWebRequest;

            return request;
        }

        private string GetHttpWebResponse(HttpWebRequest request)
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

                Console.WriteLine(content);
                response.Close();
                return content;
            }

        }

        private void Do()
        {
            var request = CreateHttpWebRequest();

            var response = GetHttpWebResponse(request);

            Console.WriteLine(response);
        }

        public void TestThreadSafe()
        {
            Task[] tasks = new Task[_threadCount];

            for (int i = 0; i < _threadCount; ++i)
            {
                tasks[i] = Task.Run(() => Do());
            }

            Task.WaitAll(tasks);
        }
    }
}
