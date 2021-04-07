using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Payment.Application.Abstractions.Services;

namespace Tiketon.Services.Payment.Application.Commands
{
    public class OrderPaymentRequestCommandHandler : IRequestHandler<OrderPaymentRequestCommand, bool>
    {
        private readonly IExternalGatewayPaymentService _externalGatewayPaymentService;

        public OrderPaymentRequestCommandHandler(IExternalGatewayPaymentService externalGatewayPaymentService)
        {
            _externalGatewayPaymentService = externalGatewayPaymentService;
        }

        public Task<bool> Handle(OrderPaymentRequestCommand request, CancellationToken cancellationToken)
        {
            return _externalGatewayPaymentService.PerformPayment(request.PaymentInfo);
        }
    }
}