using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace YuqueOAuthSample
{
    class Program
    {
        private static Random random = new Random();
        private static string urlAuthorize = "https://www.yuque.com/oauth2/authorize";
        private static string urlToken = "https://www.yuque.com/oauth2/token";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GetResponseFromAuthorize();
        }

        private static void GetResponseFromAuthorize()
        {
            var clientId = "Td8Sk8TtJw2ahfakTKjw";
            var code = GenerateString(40, false);

            var responseType = "code";
            var scope = "doc";
            var state = "running";
            var redirectUrl = "http://localhost:5001/yuque";

            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            var computeSign = ComputeSign(clientId, code, responseType, scope, timeStamp);

            var sign = Convert.ToBase64String(ComputeSecret(computeSign));

            var queryDic = new Dictionary<string, string>();
            queryDic.Add("client_id", clientId);
            //queryDic.Add("code", code);
            queryDic.Add("response_type", responseType);
            queryDic.Add("scope", scope);
            queryDic.Add("redirect_uri", redirectUrl);
            queryDic.Add("state", state);
            //queryDic.Add("timestamp", timeStamp);
            //queryDic.Add("sign", sign);

            var fullAuthorizeUrl = GetFullUrl(urlAuthorize, queryDic);

            var queryDicToken = new Dictionary<string, string>();
            queryDicToken.Add("client_id", clientId);
            queryDicToken.Add("code", code);
            queryDicToken.Add("grant_type", "client_code");

            var fullTokenUrl = GetFullUrl(urlToken, queryDicToken);


            var httpRequest = WebRequest.Create(new Uri(fullAuthorizeUrl)) as HttpWebRequest;
            var response = httpRequest.GetResponse() as HttpWebResponse;

            using (var stream = response.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                var value = streamReader.ReadToEnd();

                Console.WriteLine(value);
            }

            //var httpRequest2 = WebRequest.Create(new Uri(fullTokenUrl)) as HttpWebRequest;
            //httpRequest2.Method = "Post";

            //var response2 = httpRequest2.GetResponse() as HttpWebResponse;

            //using (var stream = response2.GetResponseStream())
            //{
            //    StreamReader streamReader = new StreamReader(stream);
            //    var value = streamReader.ReadToEnd();

            //    Console.WriteLine(value);
            //}

            //var httpRequest3 = WebRequest.Create(new Uri("http://localhost:5001/yuque?state=111&code=222"));

            //var response3 = httpRequest3.GetResponse();

            //using (var stream = response3.GetResponseStream())
            //{
            //    StreamReader streamReader = new StreamReader(stream);
            //    var value = streamReader.ReadToEnd();

            //    Console.WriteLine(value);
            //}
        }

        private static string GetFullUrl(string url, Dictionary<string, string> queryDictionary)
        {
            url += "?";
            foreach (var keyValuePair in queryDictionary)
            {
                url += $"{keyValuePair.Key}={keyValuePair.Value}&";
            }

            url = url.TrimEnd('&');

            return url;
        }

        private static byte[] ComputeSecret(string signString)
        {
            var secretByteArray = Encoding.ASCII.GetBytes(secret);

            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] byteSignString = Encoding.ASCII.GetBytes(signString);

                var key1 = sha1.ComputeHash(byteSignString);
                var key2 = key1.Concat(secretByteArray).ToArray();
                var key3 = sha1.ComputeHash(key2);

                return key3;
            }

        }

        private static string GenerateString(int size, bool lowercase)
        {
            var stringBuilder = new StringBuilder();

            char ch;

            for (int i = 0; i < size / 2; ++i)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(ch);
                stringBuilder.Append(random.Next(10));
            }

            return lowercase ? stringBuilder.ToString().ToLower() : stringBuilder.ToString();
        }

        private static string ComputeSign(string clientId, string code, string responseType, string scope, string timestamp)
        {
            return
                $"client_id={StringUrlEncode(clientId)}&code={StringUrlEncode(code)}&response_type={StringUrlEncode(responseType)}" +
                $"&scope={StringUrlEncode(scope)}&timestamp={StringUrlEncode(timestamp)}";
        }

        private static string StringUrlEncode(string args)
        {
            return System.Web.HttpUtility.UrlEncode(args);
        }
    }
}
