using System;
using MediatR;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Application.Queries.Coupons
{
    public record GetCouponByIdQuery : IRequest<Coupon>
    {
        public GetCouponByIdQuery(Guid couponId)
        {
            CouponId = couponId;
        }

        public Guid CouponId { get; }
    }
}