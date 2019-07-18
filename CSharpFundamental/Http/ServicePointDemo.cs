using System;
using System.Management.Instrumentation;
using System.Net;
using System.Threading;

namespace CSharpFundamental.Http
{
    internal class ServicePointDemo
    {
        public static void Execute()
        {
            var uri = new Uri("http://www.baidu.com");

            makeWebRequest(uri.GetHashCode(), uri);

            Thread.Sleep(5000);

            var uri2 = new Uri("http://news.baidu.com/");

            makeWebRequest(uri2.GetHashCode(), uri2);
        }

        private static void RunServicePoint(Uri uri)
        {
            Thread.Sleep(4000);
            Console.WriteLine("---------------");

            var servicePoint = ServicePointManager.FindServicePoint(uri);
            ShowProperties(servicePoint);
        }


        private static void makeWebRequest(int hashCode, Uri uri)
        {
            HttpWebResponse res = null;

            try
            {
                // Create a request to the passed URI.
                var req = (HttpWebRequest)WebRequest.Create(uri);

                Console.WriteLine("\nConnecting to " + uri + " ............");

                // Get the response object.
                res = (HttpWebResponse)req.GetResponse();

                Console.WriteLine("Connected. \n");

                var currentServicePoint = req.ServicePoint;

                // Display new service point properties.
                var currentHashCode = currentServicePoint.GetHashCode();

                Console.WriteLine("New service point hashcode: " + currentHashCode);
                Console.WriteLine("New service point max idle time: " + currentServicePoint.MaxIdleTime);
                Console.WriteLine("New service point is idle since " + currentServicePoint.IdleSince);

                ShowProperties(currentServicePoint);

                // Check that a new ServicePoint instance has been created.
                if (hashCode == currentHashCode)
                {
                    Console.WriteLine("Service point reused.");
                }
                else
                {
                    Console.WriteLine("A new service point created.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            finally
            {
                if (res != null)
                {
                    res.Close();
                }
            }
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

            if (sp.Certificate == null)
            {
                Console.WriteLine("Certificate = (null)");
            }
            else
            {
                Console.WriteLine("Certificate = " + sp.Certificate);
            }

            if (sp.ClientCertificate == null)
            {
                Console.WriteLine("ClientCertificate = (null)");
            }
            else
            {
                Console.WriteLine("ClientCertificate = " + sp.ClientCertificate);
            }

            Console.WriteLine("ProtocolVersion = " + sp.ProtocolVersion);
            Console.WriteLine("SupportsPipelining = " + sp.SupportsPipelining);

            Console.WriteLine("UseNagleAlgorithm = " + sp.UseNagleAlgorithm);
            Console.WriteLine("Expect 100-continue = " + sp.Expect100Continue);
        }

        public static IPEndPoint BindIPEndPoint1(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            string IP = remoteEndPoint.ToString();

            Console.WriteLine("IP:" + IP);
            return remoteEndPoint;
        }
    }
}
