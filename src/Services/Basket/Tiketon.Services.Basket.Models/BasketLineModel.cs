using System;

namespace Tiketon.Services.Basket.Models
{
    public class BasketLineModel
    {
        public Guid BasketLineId { get; set; }
        public Guid BasketId { get; set; }
        public Guid EventId { get; set; }
        public int Price { get; set; }
        public int TicketAmount { get; set; }
        public EventModel Event { get; set; }
    }
}