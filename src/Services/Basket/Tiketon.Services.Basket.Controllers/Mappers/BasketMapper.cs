using System.Collections.Generic;
using System.Linq;
using Tiketon.Services.Basket.Application.IntegrationEvents;
using Tiketon.Services.Basket.Domain.Entities;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers.Mappers
{
    public static class BasketMapper
    {
        public static BasketModel ToModel(this Domain.Entities.Basket source)
        {
            if (source == null)
                return null;

            return new BasketModel
            {
                BasketId = source.BasketId,
                CouponId = source.CouponId,
                UserId = source.UserId,
                NumberOfItems = source.BasketLines?.Sum(bl => bl?.TicketAmount) ?? 0
            };
        }

        public static Domain.Entities.Basket ToDomain(this BasketForCreationModel source)
        {
            if (source == null)
                return null;

            return new Domain.Entities.Basket
            {
                UserId = source.UserId
            };
        }

        public static BasketCheckoutEvent ToEvent(
            this BasketCheckoutModel source,
            ICollection<BasketLine> basketLines = null,
            CouponModel coupon = null)
        {
            if (source == null)
                return null;

            var basketCheckoutEvent = new BasketCheckoutEvent
            {
                Address = source.Address,
                City = source.City,
                Country = source.Country,
                Email = source.Email,
                BasketId = source.BasketId,
                BasketTotal = 0,
                CardExpiration = source.CardExpiration,
                CardName = source.CardName,
                CardNumber = source.CardNumber,
                FirstName = source.FirstName,
                LastName = source.LastName,
                UserId = source.UserId,
                ZipCode = source.ZipCode
            };

            if (basketLines == null || !basketLines.Any()) return basketCheckoutEvent;

            basketCheckoutEvent.BasketLines = new List<BasketLineEvent>();

            foreach (var basketLine in basketLines.ToList())
            {
                var basketLineEvent = new BasketLineEvent
                {
                    BasketLineId = basketLine.BasketLineId,
                    Price = basketLine.Price,
                    TicketAmount = basketLine.TicketAmount
                };

                basketCheckoutEvent.BasketTotal += basketLine.Price * basketLine.TicketAmount;

                basketCheckoutEvent.BasketLines.Add(basketLineEvent);
            }

            if (coupon == null) return basketCheckoutEvent;

            basketCheckoutEvent.BasketTotal -= coupon.Amount;

            return basketCheckoutEvent;
        }
    }
}