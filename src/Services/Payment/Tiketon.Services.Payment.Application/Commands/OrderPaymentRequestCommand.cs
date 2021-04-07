using MediatR;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Application.Commands
{
    public class OrderPaymentRequestCommand : IRequest<bool>
    {
        public OrderPaymentRequestCommand(PaymentInfo paymentInfo)
        {
            PaymentInfo = paymentInfo;
        }

        public PaymentInfo PaymentInfo { get; }
    }
}