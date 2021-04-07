using Tiketon.Services.Basket.Domain.Entities;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers.Mappers
{
    public static class EventMapper
    {
        public static EventModel ToModel(this Event source)
        {
            if (source == null)
                return null;

            return new EventModel
            {
                Date = source.Date,
                Name = source.Name,
                EventId = source.EventId
            };
        }
    }
}