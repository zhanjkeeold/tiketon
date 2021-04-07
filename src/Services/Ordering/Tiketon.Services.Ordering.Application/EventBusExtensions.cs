using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Ordering.Application.IntegrationEvents;

namespace Tiketon.Services.Ordering.Application
{
    public static class AppBuilderExtensions
    {
        public static IEventBus AddSubscriptions(this IEventBus eventBus)
        {
            eventBus.SubscribeDynamic<BasketCheckoutEventHandler>("BasketCheckoutEvent");
            eventBus.SubscribeDynamic<OrderPaymentUpdatedEventHandler>("OrderPaymentUpdatedEvent");
            return eventBus;
        }
    }
}