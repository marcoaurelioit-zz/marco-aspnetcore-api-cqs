using Marco.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class LogServiceCollectionExtensions
    {
        public static IServiceCollection AddMarcoLogging(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var logConfiguration = configuration.GetSection(nameof(LogConfiguration)).TryGet<LogConfiguration>();

            switch (logConfiguration.LogType.Value)
            {
                case LogType.Serilog:
                    var loggerConfiguration = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .MinimumLevel.Override("System", LogEventLevel.Error)
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                        .MinimumLevel.Override("Furiza", LogEventLevel.Warning)
                        .ReadFrom.Configuration(configuration.GetSection(nameof(LogConfiguration)))
                        .Enrich.WithExceptionDetails();

                    if (logConfiguration.LogWriteType != LogWriteType.Custom)
                    {
                        loggerConfiguration = loggerConfiguration
                            .Enrich.FromLogContext()
                            .Enrich.WithProcessId()
                            .Enrich.WithProcessName()
                            .Enrich.WithThreadId()
                            .Enrich.WithEnvironmentUserName()
                            .Enrich.WithMachineName();

                        if (logConfiguration.LogWriteType == LogWriteType.File)
                            loggerConfiguration = loggerConfiguration.WriteTo.Async(a => a.File($"logs/log-.txt", rollingInterval: RollingInterval.Day));
                        else
                            loggerConfiguration = loggerConfiguration.WriteTo.Async(a => a.Console(new JsonFormatter()));
                    }

                    services.AddLogging(c =>
                    {
                        c.ClearProviders();

                        Log.Logger = loggerConfiguration.CreateLogger();

                        c.AddSerilog();
                    });
                    break;
                case LogType.Default:
                default:
                    throw new InvalidOperationException($"Logging provider '{logConfiguration.LogType.Value}' unavailable.");
            }

            return services;
        }
    }
}