using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.WebEncoders;
using MiddlewareDemo.Middleware;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MiddlewareDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration)
               .WriteTo.RollingFile(Path.GetFullPath("logs/log-{Date}.txt"))
               .CreateLogger();
        }
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
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            //add route /files for invoke specific StaticFile
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //        Path.Combine(Directory.GetCurrentDirectory(), @"StaticFile")),
            //    RequestPath = new PathString("/files"),
            //    OnPrepareResponse = orp =>
            //    {
            //        orp.Context.Response.Headers.Append("Cache-Control", "Public,max-age=600");
            //    }
            //});

            //Custom Middleware RequestCulture
            app.UseRequestCulture();
            // route localhost:5000/map1
            app.Map("/map1", HandleMap1);
            //route localhost:5000/map2
            app.Map("/map2", HandleMap2);
            //route localhost:5000/?para={_}
            app.MapWhen(context => context.Request.Query.ContainsKey("para"), HandleMapWhenBranch);

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{Controller=Home}/{Action=Index}/{Id?}");
            });
        }
    }
}
