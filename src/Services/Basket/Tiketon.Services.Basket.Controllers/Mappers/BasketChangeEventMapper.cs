using Tiketon.Services.Basket.Domain.Entities;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers.Mappers
{
    public static class BasketChangeEventMapper
    {
        public static BasketChangeEventForPublicationModel ToModel(this BasketChangeEvent source)
        {
            if (source == null)
                return null;

            return new BasketChangeEventForPublicationModel
            {
                Id = source.Id,
                EventId = source.EventId,
                InsertedAt = source.InsertedAt,
                UserId = source.UserId,
                BasketChangeTypeModel = (BasketChangeTypeModel) source.BasketChangeType
            };
        }
    }
}