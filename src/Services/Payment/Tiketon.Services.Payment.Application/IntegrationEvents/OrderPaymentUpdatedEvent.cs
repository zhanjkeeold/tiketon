using System;
using Tiketon.BuildingBlocks.EventBus.Events;

namespace Tiketon.Services.Payment.Application.IntegrationEvents
{
    public record OrderPaymentUpdatedEvent : IntegrationEvent
    {
        public OrderPaymentUpdatedEvent(Guid orderId, bool paymentSuccess)
        {
            OrderId = orderId;
            PaymentSuccess = paymentSuccess;
        }

        public OrderPaymentUpdatedEvent(Guid id, DateTime createDate, Guid orderId, bool paymentSuccess) : base(id,
            createDate)
        {
            OrderId = orderId;
            PaymentSuccess = paymentSuccess;
        }

        public Guid OrderId { get; }
        public bool PaymentSuccess { get; }
    }
}