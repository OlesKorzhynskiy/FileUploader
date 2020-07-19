using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FileUploader.API.Infrastructure.Extensions
{
    public static class LoggerExtensions
    {
        public static IServiceCollection WithLogger(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss.fff}] [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return services;
        }
    }
}