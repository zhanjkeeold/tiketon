using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tiketon.Web.Extensions;
using Tiketon.Web.Models;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public class ShoppingBasketService : IShoppingBasketService
    {
        private readonly HttpClient _client;
        private readonly Settings _settings;

        public ShoppingBasketService(HttpClient client, Settings settings)
        {
            _client = client;
            _settings = settings;
        }

        public async Task<BasketLine> AddToBasket(Guid basketId, BasketLineForCreation basketLine)
        {
            if (basketId == Guid.Empty)
            {
                var basketResponse =
                    await _client.PostAsJson("/api/baskets", new BasketForCreation {UserId = _settings.UserId});
                var basket = await basketResponse.ReadContentAs<Basket>();
                basketId = basket.BasketId;
            }

            var response = await _client.PostAsJson($"api/baskets/{basketId}/basketlines", basketLine);
            return await response.ReadContentAs<BasketLine>();
        }

        public async Task<Basket> GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return null;
            var response = await _client.GetAsync($"/api/baskets/{basketId}");
            return await response.ReadContentAs<Basket>();
        }

        public async Task<IEnumerable<BasketLine>> GetLinesForBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
                return new BasketLine[0];
            var response = await _client.GetAsync($"/api/baskets/{basketId}/basketLines");
            return await response.ReadContentAs<BasketLine[]>();
        }

        public async Task UpdateLine(Guid basketId, BasketLineForUpdate basketLineForUpdate)
        {
            await _client.PutAsJson($"/api/baskets/{basketId}/basketLines/{basketLineForUpdate.LineId}",
                basketLineForUpdate);
        }

        public async Task RemoveLine(Guid basketId, Guid lineId)
        {
            await _client.DeleteAsync($"/api/baskets/{basketId}/basketLines/{lineId}");
        }

        public async Task ApplyCouponToBasket(Guid basketId, CouponForUpdate couponForUpdate)
        {
            var response = await _client.PutAsJson($"/api/baskets/{basketId}/coupon", couponForUpdate);
            //return await response.ReadContentAs<Coupon>();
        }

        public async Task<BasketForCheckout> Checkout(Guid basketId, BasketForCheckout basketForCheckout)
        {
            var response = await _client.PostAsJson("api/baskets/checkout", basketForCheckout);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<BasketForCheckout>();
            throw new Exception("При оформлении заказа произошла ошибка. Пожалуйста, попробуйте еще раз.");
        }
    }
}