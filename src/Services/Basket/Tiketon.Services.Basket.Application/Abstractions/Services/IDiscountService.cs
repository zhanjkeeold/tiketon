using System;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Application.Abstractions.Dtos;

namespace Tiketon.Services.Basket.Application.Abstractions.Services
{
    public interface IDiscountService
    {
        Task<CouponDto> GetCoupon(Guid couponId);
        Task<CouponDto> GetCouponWithError(Guid couponId);
    }
}