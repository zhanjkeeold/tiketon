using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Tiketon.Services.Catalog.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            return services;
        }
    }
}