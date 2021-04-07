using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tiketon.Grpc;
using Tiketon.Services.Payment.Application.Abstractions.Services;
using Tiketon.Services.Payment.Infrastucture.Services;

namespace Tiketon.Services.Payment.Infrastucture
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var baseAddress = new Uri(configuration.GetValue<string>("ApiConfigs:ExternalPaymentGateway:Uri"));

            // services.AddHttpClient<IExternalGatewayPaymentService, ExternalGatewayPaymentService>(c =>
            //     c.BaseAddress = baseAddress);

            services.AddGrpcClient<ExternalPaymentGateway.ExternalPaymentGatewayClient>(o =>
                o.Address = baseAddress);

            services.AddScoped<IExternalGatewayPaymentService, ExternalGatewayPaymentGrpcService>();

            return services;
        }
    }
}