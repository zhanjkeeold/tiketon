using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Application.Abstractions.Dtos;
using Tiketon.Services.Basket.Application.Abstractions.Services;
using Tiketon.Services.Basket.Infrastructure.Extensions;

namespace Tiketon.Services.Basket.Infrastructure.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _client;

        public DiscountService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CouponDto> GetCoupon(Guid couponId)
        {
            var response = await _client.GetAsync($"/api/discount/{couponId}");
            return await response.ReadContentAs<CouponDto>();
        }

        public async Task<CouponDto> GetCouponWithError(Guid couponId)
        {
            var response = await _client.GetAsync($"/api/discount/error/{couponId}");
            return await response.ReadContentAs<CouponDto>();
        }
    }
}