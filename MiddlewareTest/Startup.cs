using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using MiddlewareTest.Middleware;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace MiddlewareTest
{
    public class Startup
    {
        private static void HandleMap1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello,from HanleMap1");
            });
        }

        private static void HandleMap2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello,from HandleMap2");
            });
        }

        public static void HandleMapWhenBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var paraName = context.Request.Query["para"];
                await context.Response.WriteAsync($"Hello,from {paraName}");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<WebEncoderOptions>(options => options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRequestCulture();

            app.Map("/map1", HandleMap1);

            app.Map("/map2", HandleMap2);

            app.MapWhen(context => context.Request.Query.ContainsKey("para"), HandleMapWhenBranch);

            app.Run(async context =>
            {
                context.Response.ContentType = "text/plain;charset=utf-8";
                await context.Response.WriteAsync($"Hello,from Robert!" +
                    $"The Culture there 是 {CultureInfo.CurrentCulture.DisplayName} \n" +
                    $"{CultureInfo.CurrentCulture.EnglishName}");
            });
        }
    }
}
