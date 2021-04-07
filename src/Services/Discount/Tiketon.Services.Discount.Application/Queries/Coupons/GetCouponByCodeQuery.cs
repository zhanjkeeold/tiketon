using MediatR;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Application.Queries.Coupons
{
    public record GetCouponByCodeQuery : IRequest<Coupon>
    {
        public GetCouponByCodeQuery(string couponCode)
        {
            CouponCode = couponCode;
        }

        public string CouponCode { get; }
    }
}