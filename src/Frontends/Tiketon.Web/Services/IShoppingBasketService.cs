using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public interface IShoppingBasketService
    {
        Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine);
        Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId);
        Task<Basket> GetBasket(Guid basketId);
        Task UpdateLine(Guid basketId, BasketLineForUpdate basketLineForUpdate);
        Task RemoveLine(Guid basketId, Guid lineId);
        Task ApplyCouponToBasket(Guid basketId, CouponForUpdate couponForUpdate);
        Task<BasketForCheckout> Checkout(Guid basketId, BasketForCheckout basketForCheckout);
    }
}