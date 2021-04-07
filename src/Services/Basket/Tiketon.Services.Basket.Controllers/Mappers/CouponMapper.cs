using Tiketon.Services.Basket.Application.Abstractions.Dtos;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers.Mappers
{
    public static class CouponMapper
    {
        public static CouponModel ToModel(this CouponDto source)
        {
            if (source == null)
                return null;

            return new CouponModel
            {
                Amount = source.Amount,
                Code = source.Code,
                AlreadyUsed = source.AlreadyUsed,
                CouponId = source.CouponId
            };
        }
    }
}