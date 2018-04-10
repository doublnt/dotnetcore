using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EventBusDemo {
    public class Startup {
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
        }

        public void Configure (IApplicationBuilder app, IServiceProvider provider) { }
    }
}