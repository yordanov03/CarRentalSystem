using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson();

            return services;
        }
    }
}
