using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Http
{
    class ServicePointDemo
    {
        public static void Execute()
        {
            var hashCode = "YinXi".GetHashCode();
            string uri = "https://www.aliyun.com";

            makeWebRequest(hashCode, uri);
        }


        private static void makeWebRequest(int hashCode, string Uri)
        {
            HttpWebResponse res = null;

            // Make sure that the idle time has elapsed, so that a new 
            // ServicePoint instance is created.
            Console.WriteLine("Sleeping for 2 sec.");
            Thread.Sleep(2000);
            try
            {
                // Create a request to the passed URI.
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uri);

                Console.WriteLine("\nConnecting to " + Uri + " ............");

                // Get the response object.
                res = (HttpWebResponse)req.GetResponse();
                Console.WriteLine("Connected.\n");

                ServicePoint currentServicePoint = req.ServicePoint;

                // Display new service point properties.
                int currentHashCode = currentServicePoint.GetHashCode();

                Console.WriteLine("New service point hashcode: " + currentHashCode);
                Console.WriteLine("New service point max idle time: " + currentServicePoint.MaxIdleTime);
                Console.WriteLine("New service point is idle since " + currentServicePoint.IdleSince);

                ShowProperties(currentServicePoint);

                // Check that a new ServicePoint instance has been created.
                if (hashCode == currentHashCode)
                    Console.WriteLine("Service point reused.");
                else
                    Console.WriteLine("A new service point created.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            finally
            {
                if (res != null)
                    res.Close();
            }
        }

        private static void ShowProperties(ServicePoint sp)
        {
            Console.WriteLine("Done calling FindServicePoint()...");

            // Display the ServicePoint Internet resource address.
            Console.WriteLine("Address = {0} ", sp.Address.ToString());

            // Display the date and time that the ServicePoint was last 
            // connected to a host.
            Console.WriteLine("IdleSince = " + sp.IdleSince.ToString());

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
                Console.WriteLine("Certificate = (null)");
            else
                Console.WriteLine("Certificate = " + sp.Certificate.ToString());

            if (sp.ClientCertificate == null)
                Console.WriteLine("ClientCertificate = (null)");
            else
                Console.WriteLine("ClientCertificate = " + sp.ClientCertificate.ToString());

            Console.WriteLine("ProtocolVersion = " + sp.ProtocolVersion.ToString());
            Console.WriteLine("SupportsPipelining = " + sp.SupportsPipelining);

            Console.WriteLine("UseNagleAlgorithm = " + sp.UseNagleAlgorithm.ToString());
            Console.WriteLine("Expect 100-continue = " + sp.Expect100Continue.ToString());
        }
    }
}
