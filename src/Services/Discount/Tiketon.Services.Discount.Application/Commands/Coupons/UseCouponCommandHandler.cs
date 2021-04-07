using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Discount.Application.Abstractions.Repositories;

namespace Tiketon.Services.Discount.Application.Commands.Coupons
{
    public class UseCouponCommandHandler : IRequestHandler<UseCouponCommand>
    {
        private readonly ICouponRepository _couponRepository;

        public UseCouponCommandHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
        }

        public Task<Unit> Handle(UseCouponCommand request, CancellationToken cancellationToken)
        {
            _couponRepository.UseCouponAsync(request.CouponId, cancellationToken);
            return Unit.Task;
        }
    }
}