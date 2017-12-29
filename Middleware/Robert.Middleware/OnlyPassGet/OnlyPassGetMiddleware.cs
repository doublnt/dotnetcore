using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Robert.Middleware.OnlyPassGet {
    public class OnlyPassGetMiddleware {
        private readonly RequestDelegate _next;

        public OnlyPassGetMiddleware (RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke (HttpContext context) {
            if (context.Request.Method == "GET") {
                await context.Response.WriteAsync("111");
            }
            // Call the next delegate/middleware in the pipeline
            await this._next (context);
        }
    }
}