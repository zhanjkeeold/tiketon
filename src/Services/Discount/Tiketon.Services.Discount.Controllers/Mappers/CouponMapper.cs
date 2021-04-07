using Tiketon.Services.Discount.Domain.Entities;
using Tiketon.Services.Discount.Models;

namespace Tiketon.Services.Discount.Controllers.Mappers
{
    public static class CouponMapper
    {
        public static CouponModel? ToModel(this Coupon? source)
        {
            if (source is null) return null;

            return new CouponModel(
                source.CouponId,
                source.Code,
                source.Amount,
                source.AlreadyUsed);
        }
    }
}