using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Payment.Application.Commands;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Application.IntegrationEvents
{
    public class OrderPaymentRequestEventHandler : IDynamicIntegrationEventHandler
    {
        private readonly IEventBus _eventBus;
        private readonly ILogger<OrderPaymentRequestEventHandler> _logger;
        private readonly IMediator _mediator;

        public OrderPaymentRequestEventHandler(IMediator mediator,
            IEventBus eventBus, ILogger<OrderPaymentRequestEventHandler> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _logger = logger;
        }

        public Task Handle(dynamic eventData)
        {
            if (eventData is null) return Task.CompletedTask;

            JObject jsonObject = eventData;

            return Handle(jsonObject.ToObject<OrderPaymentRequestEvent>());
        }

        private async Task Handle(OrderPaymentRequestEvent orderPaymentRequest)
        {
            var paymentInfo = new PaymentInfo
            {
                CardNumber = orderPaymentRequest.CardNumber,
                CardName = orderPaymentRequest.CardName,
                CardExpiration = orderPaymentRequest.CardExpiration,
                Total = orderPaymentRequest.Total
            };

            var paymentProcessStatus = await _mediator.Send(new OrderPaymentRequestCommand(paymentInfo));

            var orderPaymentUpdateMessage = new OrderPaymentUpdatedEvent(
                orderPaymentRequest.OrderId,
                paymentProcessStatus);

            try
            {
                // Отправляем результат платежа в шину.
                _eventBus.Publish(orderPaymentUpdateMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            _logger.LogDebug($"{orderPaymentRequest.OrderId}: ServiceBusListener received item.");
            await Task.Delay(20000);
            _logger.LogDebug($"{orderPaymentRequest.OrderId}:  ServiceBusListener processed item.");
        }
    }
}