using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webhook_post_sample.Controllers
{
    public class YuqueController : Controller
    {
        private static string urlToken = "https://www.yuque.com/oauth2/token";

        [Route("yuque")]
        [HttpGet("state")]
        public JsonResult Index(string state, string code)
        {
            Console.WriteLine($"State is {state},Code is {code}");
            var token = GetTokenByCode(code);

            Console.WriteLine($"Token is {token}");
            return Json($"Good Good Study.{state}{code}");
        }

        private string GetTheSign(string client_id, string code, string response_type, string scope, string timestamp)
        {
            return $"{GetUrlEncodeValue(client_id)}&{GetUrlEncodeValue(code)}&{GetUrlEncodeValue(response_type)}&" +
                   $"{scope}&{timestamp}";
        }

        private string GetUrlEncodeValue(string value)
        {
            return UrlEncoder.Default.Encode(value);
        }

        private string GetTokenByCode(string code)
        {
            var queryDicToken = new Dictionary<string, string>();
            queryDicToken.Add("client_id", "Td8Sk8TtJw2ahfakTKjw");
            queryDicToken.Add("code", code);
            queryDicToken.Add("grant_type", "authorization_code");

            var fullTokenUrl = GetFullUrl(urlToken, queryDicToken);

            var httpRequest2 = WebRequest.Create(new Uri(fullTokenUrl)) as HttpWebRequest;
            httpRequest2.Method = "Post";

            var response2 = httpRequest2.GetResponse() as HttpWebResponse;

            using (var stream = response2.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                var value = streamReader.ReadToEnd();

                Console.WriteLine(value);

                return value;
            }
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
    }
}
