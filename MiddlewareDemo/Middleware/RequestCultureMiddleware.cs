using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Globalization;

namespace MiddlewareDemo.Middleware
{
    public class RequestCultureMiddleware
    {
        public readonly RequestDelegate _nextRequestDelegate;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _nextRequestDelegate = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var cultureQuery = httpContext.Request.Query["culture"];
            if (!string.IsNullOrEmpty(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            // Call the next delegate/middleware in the pipeline
            return this._nextRequestDelegate(httpContext);
        }
    }
}
