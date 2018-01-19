using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Robert.Middleware.OnlyPassGet
{
    public class OnlyPassGetMiddleware
    {
        private readonly RequestDelegate _next;

        public OnlyPassGetMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("系统维护中...");
            }
            // Call the next delegate/middleware in the pipeline
            else
            {
                await this._next(context);
            }
        }
    }
}