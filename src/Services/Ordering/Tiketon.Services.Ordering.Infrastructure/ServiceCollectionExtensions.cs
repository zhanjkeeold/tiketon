using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;
using Tiketon.Services.Ordering.Infrastructure.Persistence;
using Tiketon.Services.Ordering.Infrastructure.Persistence.Repositories;

namespace Tiketon.Services.Ordering.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<OrderDbContext>(options => { options.UseSqlServer(connectionString); });

            services.AddScoped<IOrderRepository, OrderRepository>();

            var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            services.AddSingleton(new OrderRepository(optionsBuilder.Options));

            return services;
        }
    }
}