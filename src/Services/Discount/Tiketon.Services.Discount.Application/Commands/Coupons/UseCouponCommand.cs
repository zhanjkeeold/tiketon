using System;
using MediatR;

namespace Tiketon.Services.Discount.Application.Commands.Coupons
{
    public record UseCouponCommand : IRequest
    {
        public UseCouponCommand(Guid couponId)
        {
            CouponId = couponId;
        }

        public Guid CouponId { get; }
    }
}