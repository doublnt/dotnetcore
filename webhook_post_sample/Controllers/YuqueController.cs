using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webhook_post_sample.Controllers
{
    public class YuqueController : Controller
    {
        [Route("yuque")]
        public JsonResult Index([FromBody]string state, [FromBody] string code)
        {
            string clientId = "E95mSq5K6VjchHyxUpO0";
            string code = 

            return Json($"State is {state}, Code is {code}");
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
    }
}
