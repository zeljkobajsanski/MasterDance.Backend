using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using MasterDance.Web.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MasterDance.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public IConfiguration Configuration { get; }
        public ILogger Logger { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Logger.LogDebug("Configuring services");
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opts => { opts.SerializerSettings.DateFormatString = "dd.MM.yyyy"; })
                    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAutoMapper();
            services.AddMediatR();
            //services.AddDbContext<MasterDanceContext>(cfg => cfg.UseInMemoryDatabase("MasterDance"));
            services.AddDbContext<MasterDanceContext>(cfg =>
                {
                    cfg.UseSqlServer(Configuration.GetConnectionString("MasterDance"));
                    cfg.EnableSensitiveDataLogging(true);
                }
            );
            //services.AddDbContext<MasterDanceContext>(cfg => cfg.UseSqlite("Filename=MasterDance.db"));
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
                app.UseHsts();
            }

            app.UseExceptionHandler(builder => builder.Run(async (c) =>
            {
                c.Response.StatusCode = 500;
                c.Response.ContentType = "application/json";
                var contextFeature = c.Features.Get<IExceptionHandlerFeature>();
                if(contextFeature != null)
                { 
                    Logger.LogError($"Something went wrong: {contextFeature.Error}");
 
                    await c.Response.WriteAsync(new
                    {
                        c.Response.StatusCode,
                        Message = "Internal Server Error."
                    }.ToString());
                }
            }));
            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseFileServer();
        }
    }
}