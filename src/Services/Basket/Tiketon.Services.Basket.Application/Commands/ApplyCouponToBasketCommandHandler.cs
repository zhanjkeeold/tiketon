using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class ApplyCouponToBasketCommandHandler : IRequestHandler<ApplyCouponToBasketCommand, bool>
    {
        private readonly IBasketRepository _basketRepository;

        public ApplyCouponToBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ??
                                throw new ArgumentNullException(nameof(basketRepository));
        }

        /// <inheritdoc />
        public async Task<bool> Handle(ApplyCouponToBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasketById(request.BasketId);
            if (basket == null) return false;

            basket.CouponId = request.CouponId;
            await _basketRepository.SaveChanges();

            return true;
        }
    }
}