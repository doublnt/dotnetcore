using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebRequestDemo
{
    internal class WebRetrieveSample
    {
        public readonly Uri DownloadUri = new Uri("https://www.cnblogs.com");

        public void DoWebRetrieveThing()
        {
            var value1 = RetrieveDataFromWebSiteUseWebClient();
            var value2 = RetrieveDataFromWebSiteUseGetResponse();
            var value3 = OpenReadFromWebClient();

            Console.WriteLine(value2 == value3);
            Console.WriteLine(value3 == value1);

            Console.WriteLine(PostDataToWebsite());
        }

        private string RetrieveDataFromWebSiteUseWebClient()
        {
            var webClient = new WebClient();

            var downloadString = webClient.DownloadString(DownloadUri);

            return downloadString;
        }

        private string RetrieveDataFromWebSiteUseGetResponse()
        {
            var request = WebRequest.Create(DownloadUri) as HttpWebRequest;

            var value = "";

            if (request != null)
            {
                var response = request.GetResponse() as HttpWebResponse;

                using (var streamReader =
                    new StreamReader(response.GetResponseStream() ?? throw new InvalidOperationException()))
                {
                    value = streamReader.ReadToEnd();

                    //Console.WriteLine(value);

                    Console.WriteLine((int)response.StatusCode);
                }
            }

            return value;
        }

        private string OpenReadFromWebClient()
        {
            var webClient = new WebClient();

            var result = "";

            var response = webClient.OpenRead(DownloadUri);

            using (var streamReader = new StreamReader(response))
            {
                result = streamReader.ReadToEnd();

                //Console.WriteLine(result);
            }

            response.Close();

            return result;
        }

        private bool PostDataToWebsite()
        {
            var webrequest = WebRequest.Create(DownloadUri) as HttpWebRequest;

            webrequest.Method = "Post";
            webrequest.ContentType = "application/x-www-from-urlencoded";

            string postData = "Test Post Data string";

            var byteData = Encoding.UTF8.GetBytes(postData);

            using (Stream stream = webrequest.GetRequestStream())
            {
                stream.Write(byteData);

                // Will be always false
                Console.WriteLine("Check if can seek: " + stream.CanSeek);
            }

            var response = webrequest.GetResponse() as HttpWebResponse;

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
            {
                Console.WriteLine(streamReader.ReadToEnd());
            }

            return response.StatusCode == HttpStatusCode.OK;

        }
    }
}
