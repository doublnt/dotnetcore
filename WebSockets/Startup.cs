#define UseOptions
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.WebSockets;
using System.Threading;

namespace WebSockets
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddDebug(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region no options
            app.UseWebSockets();
            #endregion

            #region Options
            //var webSocketsOption = new WebSocketOptions()
            //{
            //    KeepAliveInterval = TimeSpan.FromSeconds(120),
            //    ReceiveBufferSize = 4 * 1024 
            //};

            //app.UseWebSockets(webSocketsOption);
            #endregion
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/ws")
                {
                    if (context.WebSockets.IsWebSocketRequest)
                    {
                        var webSockets = await context.WebSockets.AcceptWebSocketAsync();
                        await Echo(context, webSockets);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                    }
                }
                else
                {
                    await next();
                }
            });
            app.UseFileServer();
        }

        private async Task Echo(HttpContext context, WebSocket webSockets)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSockets.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                await webSockets.SendAsync(
                    new ArraySegment<byte>(buffer, 0, result.Count),
                    result.MessageType,
                    result.EndOfMessage,
                    CancellationToken.None
                    );
                result = await webSockets.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSockets.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
    }
}
