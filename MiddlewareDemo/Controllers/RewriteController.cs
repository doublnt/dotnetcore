using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace MiddlewareDemo.Controllers
{
    public class RewriteController : Controller
    {
        [Route("redirected/{id?}")]
        public string RedirectFuc()
        {
            return HttpContext.Request.Path + HttpContext.Request.QueryString;
        }

        [Route("rewritten/")]
        public string RewriteFuc(int a, int b)
        {
            return HttpContext.Request.Path + HttpContext.Request.QueryString;
        }

        [Route("multi/{id:int}")]
        public string IntParamsFunc()
        {
            return "Hello,success invoke!";
        }

        [Route("regex/{id:regex(^\\d+)}")]
        public string RegexFunc()
        {
            return "Hello,Robert, Regex Invoke Success!";
        }

        public string MultiRegexFunc()
        {
            return "Hello,Robert,Multi Regex invoke success!";
        }
    }
}
