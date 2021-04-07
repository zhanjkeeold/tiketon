using System;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json.Linq;
using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Ordering.Application.Commands;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public class OrderPaymentUpdatedEventHandler : IDynamicIntegrationEventHandler
    {
        private readonly IMediator _mediator;

        public OrderPaymentUpdatedEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <inheritdoc />
        public Task Handle(dynamic eventData)
        {
            if (eventData is null) return Task.CompletedTask;

            JObject jsonObject = eventData;

            return Handle(jsonObject.ToObject<OrderPaymentUpdatedEvent>());
        }

        public async Task Handle(OrderPaymentUpdatedEvent @event)
        {
            await _mediator.Send(new UpdateOrderPaymentStatusCommand(@event.OrderId, @event.PaymentSuccess));
        }
    }
}