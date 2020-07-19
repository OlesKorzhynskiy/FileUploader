using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploader.API.Infrastructure.Extensions
{
    public static class MapsterExtensions
    {
        public static IServiceCollection WithMapster(this IServiceCollection services)
        {
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

            return services;
        }
    }
}