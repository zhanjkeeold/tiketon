using System;
using Tiketon.BuildingBlocks.EventBus.Events;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public record OrderPaymentRequestEvent : IntegrationEvent
    {
        public Guid OrderId { get; set; }
        public int Total { get; set; }
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }
    }
}