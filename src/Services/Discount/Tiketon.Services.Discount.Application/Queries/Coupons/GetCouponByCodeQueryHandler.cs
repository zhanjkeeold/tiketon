using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Discount.Application.Abstractions.Repositories;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Application.Queries.Coupons
{
    public class GetCouponByCodeQueryHandler : IRequestHandler<GetCouponByCodeQuery, Coupon>
    {
        private readonly ICouponRepository _couponRepository;

        public GetCouponByCodeQueryHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        public Task<Coupon> Handle(GetCouponByCodeQuery request, CancellationToken cancellationToken)
        {
            return _couponRepository.GetCouponByCodeAsync(request.CouponCode, cancellationToken);
        }
    }
}