using System;
using System.Threading.Tasks;
using Grpc.Core;
using Tiketon.Grpc;

namespace External.PaymentGateway.Grpc
{
    public class PaymentGatewayService : ExternalPaymentGateway.ExternalPaymentGatewayBase
    {
        public override async Task<PaymentInfoResponse> PerformPayment(PaymentInfoRequest request,
            ServerCallContext context)
        {
            return await Task.Run(() =>
            {
                var num = new Random().Next(1000);
                return num > 500
                    ? new PaymentInfoResponse {Status = true}
                    : new PaymentInfoResponse {Status = false};
            });
        }
    }
}