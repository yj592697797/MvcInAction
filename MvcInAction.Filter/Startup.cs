using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MvcInAction.Filter.Filters;

namespace MvcInAction.Filter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<LoggerFilter2Attribute>();
            services.AddControllers(config => 
            {
                // È«¾Ö¹ýÂËÆ÷
                // config.Filters.Add(typeof(GlobalActionFilterAttribute));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            NestedApp(app);
        }

        private void NestedApp(IApplicationBuilder app)
        {
            app.Run(async context => 
            {
                string path = context.Request.Path;
                if (path == "/home")
                {
                    await HomePage(context);
                }
            });
        }

        private async Task HomePage(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"<html><body>\r\n");

            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/same-scope\">same-scope</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/same-scope-exception\">same-scope-exception</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/different-scope\">different-scope</a><br>\r\n");
            await context.Response.WriteAsync("<br>");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/specified-order-on-action-filter\">specified-order-on-action-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/specified-order-on-exception-filter\">specified-order-on-exception-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/specified-order-on-authorization-filter\">specified-order-on-authorization-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/specified-order-on-different-filter\">specified-order-on-different-filter</a><br>\r\n");
            await context.Response.WriteAsync("<br>");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/use-type-filter\">use-type-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/use-encapsulation-type-filter\">use-encapsulation-type-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<a href=\"{context.Request.PathBase}/use-service-filter\">use-service-filter</a><br>\r\n");
            await context.Response.WriteAsync($"<br>Url: {context.Request.Path}<br>\r\n");

            await context.Response.WriteAsync($"</body></html>");
        }
    }
}
