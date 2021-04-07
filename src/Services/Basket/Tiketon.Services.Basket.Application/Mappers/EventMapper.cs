using Tiketon.Services.Basket.Application.Abstractions.Dtos;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Mappers
{
    public static class EventMapper
    {
        public static Event ToDomain(this EventDto source)
        {
            if (source == null) return null;
            return new Event
            {
                Date = source.Date,
                Name = source.Name,
                EventId = source.EventId
            };
        }
    }
}