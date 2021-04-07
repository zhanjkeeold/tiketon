using System;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json.Linq;
using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Ordering.Application.Commands;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public class BasketCheckoutEventHandler : IDynamicIntegrationEventHandler
    {
        private readonly IEventBus _eventBus;
        private readonly IMediator _mediator;

        public BasketCheckoutEventHandler(IMediator mediator, IEventBus eventBus)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        /// <inheritdoc />
        public Task Handle(dynamic eventData)
        {
            if (eventData is null) return Task.CompletedTask;

            JObject jsonObject = eventData;

            return Handle(jsonObject.ToObject<BasketCheckoutEvent>());
        }

        public async Task Handle(BasketCheckoutEvent @event)
        {
            var orderId = Guid.NewGuid();

            var order = new Order
            {
                UserId = @event.UserId,
                Id = orderId,
                OrderPaid = false,
                OrderPlaced = DateTime.Now,
                OrderTotal = @event.BasketTotal
            };

            await _mediator.Send(new AddOrderCommand(order));

            // Отправляем запрос на оплату заказа.
            var orderPaymentRequestEvent = new OrderPaymentRequestEvent
            {
                CardExpiration = @event.CardExpiration,
                CardName = @event.CardName,
                CardNumber = @event.CardNumber,
                OrderId = orderId,
                Total = @event.BasketTotal
            };

            try
            {
                _eventBus.Publish(orderPaymentRequestEvent);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}