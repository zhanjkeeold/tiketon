using System;

namespace Tiketon.Services.Basket.Application.Abstractions.Dtos
{
    public class EventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}