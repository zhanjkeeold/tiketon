using System;
using Tiketon.BuildingBlocks.EventBus.Events;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public record OrderPaymentUpdatedEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public bool PaymentSuccess { get; set; }
    }
}