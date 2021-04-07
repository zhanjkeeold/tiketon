using System;
using System.Collections.Generic;
using Tiketon.BuildingBlocks.EventBus.Events;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public record BasketCheckoutEvent : IntegrationEvent
    {
        public Guid BasketId { get; set; }

        // Инфа о пользователе
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Guid UserId { get; set; }


        // Инфа о карте
        public string CardNumber { get; set; }
        public string CardName { get; set; }
        public string CardExpiration { get; set; }

        // Инфа о заказе
        public List<BasketLineEvent> BasketLines { get; set; }
        public int BasketTotal { get; set; }
    }
}