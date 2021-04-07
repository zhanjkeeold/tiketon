using System;
using MediatR;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record ApplyCouponToBasketCommand : IRequest<bool>
    {
        public ApplyCouponToBasketCommand(Guid basketId, Guid couponId)
        {
            BasketId = basketId;
            CouponId = couponId;
        }

        public Guid BasketId { get; }
        public Guid CouponId { get; }
    }
}