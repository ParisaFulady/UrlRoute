using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlRoute.Infrastructures;
using WebApplication1.Infrastructures;

namespace WebApplication1
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
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("weekday", typeof(WeekDayConstraint));
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;

            }
            //services.Configure<RouteOptions>(options =>
            //{
            //    options.ConstraintMap.Add("Codemeli", typeof(CodeMeliConstraint));
            //    options.LowercaseUrls = true;
            //    options.AppendTrailingSlash = true;

            //}

           );

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
       

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseMvc(routs =>
            {
                routs.MapRoute("default", "/{controller=home}/{action=index}/{id:weekday=sat}",
                    defaults: new { },
                    constraints: new { id = new WeekDayConstraint() });
            });
            //app.UseMvc(routs =>
            //{
            //    routs.MapRoute("default", "/{controller=home}/{action=index}/{id:Codemeli=2753647564}",
            //        defaults: new { },
            //        constraints: new { id = new CodeMeliConstraint() });
            //});
        }
    }
}
