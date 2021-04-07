using System;
using System.Threading.Tasks;
using Tiketon.Grpc;
using Tiketon.Services.Payment.Application.Abstractions.Services;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Infrastucture.Services
{
    public class ExternalGatewayPaymentGrpcService : IExternalGatewayPaymentService
    {
        private readonly ExternalPaymentGateway.ExternalPaymentGatewayClient _client;

        public ExternalGatewayPaymentGrpcService(ExternalPaymentGateway.ExternalPaymentGatewayClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> PerformPayment(PaymentInfo paymentInfo)
        {
            if (paymentInfo == null)
                throw new ArgumentNullException(nameof(paymentInfo));

            var response = await _client.PerformPaymentAsync(new PaymentInfoRequest
            {
                Total = paymentInfo.Total,
                CardExpiration = paymentInfo.CardExpiration,
                CardName = paymentInfo.CardName,
                CardNumber = paymentInfo.CardNumber
            });

            if (response is null)
            {
                // log.
            }

            return response?.Status ?? false;
        }
    }
}