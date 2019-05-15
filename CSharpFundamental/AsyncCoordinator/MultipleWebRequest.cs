using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.AsyncCoordinator
{
    class MultipleWebRequest
    {
        private AsyncCoordinator m_ac = new AsyncCoordinator();

        private Dictionary<String, Object> m_servers = new Dictionary<string, object>()
        {
            { "http://www.alibabacloud.com",null},
            {"http://www.taobao.com",null },
            {"http://1.1.1.1",null }
        };

        public MultipleWebRequest(Int32 timeout = Timeout.Infinite)
        {
            var httpClient = new HttpClient();

            m_ac.AboutToBegin(m_servers.Count);

            foreach (var server in m_servers.Keys)
            {
                httpClient.GetByteArrayAsync(server).ContinueWith(task => ComputeResult(server, task));
            }

            m_ac.AllBegun(AllDone, timeout);
        }

        private void ComputeResult(String server, Task<byte[]> task)
        {
            Object result;

            if (task.Exception != null)
            {
                result = task.Exception.InnerExceptions;
            }
            else
            {
                result = task.Result.Length;
            }

            m_servers[server] = result;
            m_ac.JustEnded();
        }

        public void Cancel()
        {
            m_ac.Cancel();
        }

        private void AllDone(CoordinationStatus status)
        {
            switch (status)
            {
                case CoordinationStatus.Cancel:
                    Console.WriteLine("Operation canceled");
                    break;
                case CoordinationStatus.Timeout:
                    Console.WriteLine("Operation timed out");
                    break;
                case CoordinationStatus.AllDone:
                    Console.WriteLine("Operation Completed; result below:");
                    foreach (var server in m_servers)
                    {
                        Console.WriteLine("{0} ", server.Key);
                        Object result = server.Value;

                        if (result is Exception)
                        {
                            Console.WriteLine("Failed due to {0}.", result.GetType().Name);
                        }
                        else
                        {
                            Console.WriteLine("Returned {0:N0} bytes", result);
                        }
                    }
                    break;
            }
        }
    }
}
