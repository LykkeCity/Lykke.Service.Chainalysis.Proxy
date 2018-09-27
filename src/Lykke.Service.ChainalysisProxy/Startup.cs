using System;
using JetBrains.Annotations;
using Lykke.Common.ApiLibrary.Middleware;
using Lykke.Common.Log;
using Lykke.Sdk;
using Lykke.Service.ChainalysisProxy.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.ChainalysisProxy
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "Chainalysis API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
            {
                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "ChainalysisProxyLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.ChainalysisProxyService.Db.LogsConnString;
                };
            });
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app)
        {
            CreateErrorResponse errorResponseFactory = ex => new { ex.Message };

            app.UseLykkeConfiguration(options =>
            {
                options.WithMiddleware = x => x.UseMiddleware<GlobalErrorHandlerMiddleware>(x.ApplicationServices.GetRequiredService<ILogFactory>(), errorResponseFactory);
                options.SwaggerOptions = _swaggerOptions;
            });
        }
    }
}
