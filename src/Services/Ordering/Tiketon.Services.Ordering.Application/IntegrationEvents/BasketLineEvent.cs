using System;

namespace Tiketon.Services.Ordering.Application.IntegrationEvents
{
    public class BasketLineEvent
    {
        public Guid BasketLineId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
    }
}