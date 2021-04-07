using Tiketon.Services.Ordering.Domain.Entities;
using Tiketon.Services.Ordering.Models;

namespace Tiketon.Services.Ordering.Controllers.Mappers
{
    public static class OrderMapper
    {
        public static OrderModel ToModel(this Order source)
        {
            if (source == null)
                return null;

            return new OrderModel
            {
                Id = source.Id,
                OrderPaid = source.OrderPaid,
                OrderPlaced = source.OrderPlaced,
                OrderTotal = source.OrderTotal,
                UserId = source.UserId
            };
        }
    }
}