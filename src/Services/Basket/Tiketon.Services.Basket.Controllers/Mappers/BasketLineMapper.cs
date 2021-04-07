using Tiketon.Services.Basket.Domain.Entities;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers.Mappers
{
    public static class BasketLineMapper
    {
        public static BasketLineModel ToModel(this BasketLine source)
        {
            if (source == null)
                return null;

            return new BasketLineModel
            {
                Price = source.Price,
                BasketId = source.BasketId,
                EventId = source.EventId,
                Event = source.Event.ToModel(),
                TicketAmount = source.TicketAmount,
                BasketLineId = source.BasketLineId
            };
        }

        public static BasketLine ToDomain(this BasketLineForCreationModel source)
        {
            if (source == null)
                return null;

            return new BasketLine
            {
                Price = source.Price,
                EventId = source.EventId,
                TicketAmount = source.TicketAmount
            };
        }

        public static BasketLine ToDomain(this BasketLineForUpdateModel source)
        {
            if (source == null)
                return null;

            return new BasketLine
            {
                TicketAmount = source.TicketAmount
            };
        }
    }
}