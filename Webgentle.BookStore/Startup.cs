using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webgentle.BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    if (env.IsEnvironment("Develop"))
                    {
                        await context.Response.WriteAsync("Hello from custom name");
                    }
                    //else if (env.IsProduction())
                    //{
                    //    await context.Response.WriteAsync("Hello from prod");
                    //}
                    //else if (env.IsStaging())
                    //{
                    //    await context.Response.WriteAsync("Hello from stag");
                    //}
                    else 
                    await context.Response.WriteAsync(env.EnvironmentName);
                });
            });
        }
    }
}
