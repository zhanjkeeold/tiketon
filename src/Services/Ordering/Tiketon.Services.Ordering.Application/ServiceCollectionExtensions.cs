using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tiketon.Services.Ordering.Application.IntegrationEvents;

namespace Tiketon.Services.Ordering.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddTransient<BasketCheckoutEventHandler>();
            services.AddTransient<OrderPaymentUpdatedEventHandler>();
            return services;
        }
    }
}