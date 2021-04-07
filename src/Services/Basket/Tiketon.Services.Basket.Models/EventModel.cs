using System;

namespace Tiketon.Services.Basket.Models
{
    public class EventModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}