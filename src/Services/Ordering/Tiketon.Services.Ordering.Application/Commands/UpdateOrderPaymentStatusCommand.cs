using System;
using MediatR;

namespace Tiketon.Services.Ordering.Application.Commands
{
    public record UpdateOrderPaymentStatusCommand : IRequest
    {
        public UpdateOrderPaymentStatusCommand(Guid orderId, bool paid)
        {
            OrderId = orderId;
            Paid = paid;
        }

        public Guid OrderId { get; }
        public bool Paid { get; }
    }
}