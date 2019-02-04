using System;
using System.Reflection;
using MasterDance.Application.Infrastructure;
using MasterDance.Infrastructure.Extensions;
using MasterDance.Persistence;
using MasterDance.Persistence.Extensions;
using MasterDance.WebUI.Extensions;
using MasterDance.WebUI.Filters;
using FluentValidation.AspNetCore;
using MasterDance.Application;
using MasterDance.WebUI.Models;
using MasterDance.WebUI.Security;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MasterDance.WebUI
{
    public class Startup
    {
        private IHostingEnvironment _hostingEnvironment;
        
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                    {
                        // options.Filters.Add(typeof(CustomExceptionFilterAttribute)) <!-- User error filter if global error handler was not set
                    }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<FluentValidatorMarkerClass>();
                    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                }).AddJsonOptions(json => { json.SerializerSettings.DateFormatString = "dd.MM.yyyy"; });

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(MediatorHandlerPlaceholderClass).GetTypeInfo().Assembly);

            // Customise default API behaviour
            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});

            // Swagger
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "MasterDance API";
                    document.Info.Description = "MasterDance ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                };
            });

            // Application modules
            services.AddInfrastructureModule(_hostingEnvironment.WebRootPath);
            services.AddPersistenceModule(Configuration.GetConnectionString("Database"));
            services.AddApplicationModule();
            
            // Identity Server
            services.AddSecurity();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            app.UseGlobalErrorHandler(loggerFactory.CreateLogger("Default")); // <-- Global error handler
            //app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUi3();
            app.UseFileServer();
            app.UseIdentityServer();
            app.UseMvc();
        }
    }
}
