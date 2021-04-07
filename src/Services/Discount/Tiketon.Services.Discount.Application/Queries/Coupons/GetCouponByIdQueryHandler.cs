using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Discount.Application.Abstractions.Repositories;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Application.Queries.Coupons
{
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, Coupon>
    {
        private readonly ICouponRepository _couponRepository;

        public GetCouponByIdQueryHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        public Task<Coupon> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
        {
            return _couponRepository.GetCouponByIdAsync(request.CouponId, cancellationToken);
        }
    }
}