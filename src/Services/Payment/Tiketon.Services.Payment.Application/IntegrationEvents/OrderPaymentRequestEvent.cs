using System;
using Newtonsoft.Json;
using Tiketon.BuildingBlocks.EventBus.Events;

namespace Tiketon.Services.Payment.Application.IntegrationEvents
{
    public record OrderPaymentRequestEvent : IntegrationEvent
    {
        [JsonConstructor]
        public OrderPaymentRequestEvent(Guid orderId, int total, string cardNumber, string cardName,
            string cardExpiration)
        {
            OrderId = orderId;
            Total = total;
            CardNumber = cardNumber;
            CardName = cardName;
            CardExpiration = cardExpiration;
        }

        [JsonProperty] public Guid OrderId { get; private init; }
        [JsonProperty] public int Total { get; private init; }
        [JsonProperty] public string CardNumber { get; private init; }
        [JsonProperty] public string CardName { get; private init; }
        [JsonProperty] public string CardExpiration { get; private init; }
    }
}