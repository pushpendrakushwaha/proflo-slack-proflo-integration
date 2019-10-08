using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.StaticFiles;

using ProfloSlackIntegration.BusinessLayer;
using ProfloSlackIntegration.DataAccess;
using ProfloSlackIntegration.Services;

namespace ProfloSlackIntegration
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
            services.AddScoped<PowerupDbContext>();

            services.AddScoped<IProfloSlackHandler, ProfloSlackHandler>();
            services.AddScoped<IProfloSlackIntegrationService, ProfloSlackIntegrationService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseStaticFiles();
            //app.UseDefaultFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/slackproflo.json", "Proflo Integration with Slack");
            });
            app.UseCors(builder => builder.WithOrigins("http://localhost:5000")
            .AllowAnyHeader().AllowAnyMethod());
        }
    }
}
