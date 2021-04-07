using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tiketon.Services.Payment.Application.IntegrationEvents;

namespace Tiketon.Services.Payment.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);
            services.AddTransient<OrderPaymentRequestEventHandler>();
            return services;
        }
    }
}