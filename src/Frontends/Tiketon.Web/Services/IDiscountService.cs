using System;
using System.Threading.Tasks;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public interface IDiscountService
    {
        Task<Coupon> GetCouponByCode(string code);
        Task UseCoupon(Guid couponId);
        Task<Coupon> GetCouponById(Guid couponId);
    }
}