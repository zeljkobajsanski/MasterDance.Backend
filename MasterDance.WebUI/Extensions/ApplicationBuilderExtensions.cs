using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MasterDance.WebUI.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalErrorHandler(this IApplicationBuilder app, ILogger logger = null)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger?.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new
                        {
                            context.Response.StatusCode,
                            Message = contextFeature.Error
                        }.ToString());
                    }
                });
            });
            return app;
        }
    }
}