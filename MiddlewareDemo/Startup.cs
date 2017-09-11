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
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Hosting;

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePagesWithReExecute("/error","?StatusCode={0}");
            
            // app.UseStatusCodePagesWithRedirects("/error");

            app.UseStaticFiles();

            env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");//It is something like rewrite url ?
            }

            #region Add route /files for invoke specific StaticFile
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
            #endregion

            //Custom Middleware RequestCulture
            app.UseRequestCulture();

            // route localhost:5000/map1
            app.Map("/map1", HandleMap1);

            //route localhost:5000/map2
            app.Map("/map2", HandleMap2);

            //route localhost:5000/?para={_}
            app.MapWhen(context => context.Request.Query.ContainsKey("para"), HandleMapWhenBranch);

            #region Url Rewrite and Redirect
            using (StreamReader apacheModRewriteStreamReader = File.OpenText("ApacheModRewrite.txt"))
            using (StreamReader iisUrlRewriteStreamReader = File.OpenText("IISUrlRewrite.xml"))
            {
                var options = new RewriteOptions()
                   .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                   .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                   .AddApacheModRewrite(apacheModRewriteStreamReader)
                   .AddIISUrlRewrite(iisUrlRewriteStreamReader);

                app.UseRewriter(options);
            }
            #endregion

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Regex",
                    template: "MultiRegex/{param1}/{param2}",
                    defaults: new { controller = "Rewrite", action = "MultiRegexFunc" },
                    constraints: new { param1 = @"^\d+", param2 = @"\d+" }
                );

                routes.MapRoute(
                    name: "Error",
                    template: "error/",
                    defaults: new { controller = "Home", action = "error" }
                );

                routes.MapRoute(
                    name: "404",
                    template: "404/",
                    defaults: new { controller = "Home", action = "pageNotFound" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{Controller}/{Action}/{Id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
