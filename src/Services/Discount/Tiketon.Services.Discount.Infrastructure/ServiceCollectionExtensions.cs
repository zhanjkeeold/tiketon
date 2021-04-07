using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tiketon.Services.Discount.Application.Abstractions.Repositories;
using Tiketon.Services.Discount.Infrastructure.Persistence;
using Tiketon.Services.Discount.Infrastructure.Persistence.Repositories;

namespace Tiketon.Services.Discount.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DiscountDbContext>(options =>
                options.UseSqlServer(connectionString,
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ServiceCollectionExtensions).Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                    }));
            services.AddScoped<ICouponRepository, CouponRepository>();

            return services;
        }
    }
}