using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WebAPIVersioning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvc();

            services.AddApiVersioning(
                options =>
                {
                    options.ApiVersionReader = ApiVersionReader.Combine(
                        new QueryStringApiVersionReader("api-version"),
                        new HeaderApiVersionReader("x-api-version"),
                        new MediaTypeApiVersionReader("version")
                    );
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v2", 
                    new OpenApiInfo
                    {
                        Title = ".NET Tech Talk - API versioning and documentation. ", 
                        Version = "v2",
                        Description = "Make love not confusion",
                        Contact = new OpenApiContact
                        {
                            Name = "Dmytro Parkhomchuk",
                            Email = string.Empty,
                            Url = new Uri("https://telescope.epam.com/who/Dmytro_Parkhomchuk"),
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
           
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var controllerNamespace = controller.ControllerType.Namespace; // e.g. "Controllers.v1"
            var apiVersion = controllerNamespace?.Split('.').Last().ToLower();
            controller.ApiExplorer.GroupName = apiVersion;
        }
    }
}
