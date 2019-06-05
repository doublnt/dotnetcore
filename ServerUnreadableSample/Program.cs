using System;
using System.Net;
using System.Net.Sockets;

using Pose;

namespace ServerUnreadableSample
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HttpWebRequest httpWebRequest = null;

            var url = "https://portal.sfdsafahadowsocks.com/";

            try
            {
                //httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
                //httpWebRequest.Timeout = 3000;

                //var response = httpWebRequest.GetResponse() as HttpWebResponse;

                //Console.WriteLine(response.ResponseUri);

                //if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                //{
                //}

                Shim exceptionResponse = Shim.Replace(() => WebRequest.Create(url).GetResponse())
                    .With(() => { new SocketException(); });
            }
            catch (SocketException socketException)
            {
                Console.WriteLine("SocketException" + socketException.SocketErrorCode);

                throw;
            }
            catch (WebException webException)
            {
                Console.WriteLine(webException.Status + "Request Url is: " + httpWebRequest.RequestUri);

                throw;
            }
        }
    }
}
