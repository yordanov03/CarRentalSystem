using CarRentalSystem.Application.Contracts;
using CarRentalSystem.Infrastructure.Persistance;
using CarRentalSystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSystem.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
           => services
               .AddDbContext<CarRentalDbContext>(options => options
                   .UseSqlServer(
                       configuration.GetConnectionString("DefaultConnection"),
                       b => b.MigrationsAssembly(typeof(CarRentalDbContext).Assembly.FullName)))
            .AddTransient(typeof(IRepository<>), typeof(DataRepository<>));
    }
}
