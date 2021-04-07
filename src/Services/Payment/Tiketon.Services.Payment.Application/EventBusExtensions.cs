using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Payment.Application.IntegrationEvents;

namespace Tiketon.Services.Payment.Application
{
    public static class AppBuilderExtensions
    {
        public static IEventBus AddSubscriptions(this IEventBus eventBus)
        {
            eventBus.SubscribeDynamic<OrderPaymentRequestEventHandler>("OrderPaymentRequestEvent");
            return eventBus;
        }
    }
}