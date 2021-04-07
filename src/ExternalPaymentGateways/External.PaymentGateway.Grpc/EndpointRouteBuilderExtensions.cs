using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace External.PaymentGateway.Grpc
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapGrpcServices(this IEndpointRouteBuilder builder)
        {
            builder.MapGrpcService<PaymentGatewayService>();
            return builder;
        }
    }
}