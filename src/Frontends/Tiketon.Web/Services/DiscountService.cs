using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tiketon.Web.Extensions;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _client;

        public DiscountService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Coupon> GetCouponByCode(string code)
        {
            if (code == string.Empty)
                return null;

            var response = await _client.GetAsync($"/api/discount/code/{code}");
            return await response.ReadContentAs<Coupon>();
        }

        public async Task<Coupon> GetCouponById(Guid couponId)
        {
            var response = await _client.GetAsync($"/api/discount/{couponId}");
            return await response.ReadContentAs<Coupon>();
        }

        public async Task UseCoupon(Guid couponId)
        {
            var response = await _client.PutAsJson($"/api/discount/use/{couponId}", new CouponForUpdate());
        }
    }
}