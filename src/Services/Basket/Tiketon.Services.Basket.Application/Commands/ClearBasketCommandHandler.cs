using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;

        public ClearBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ??
                                throw new ArgumentNullException(nameof(basketRepository));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(ClearBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketRepository.ClearBasket(request.BasketId);
            await _basketRepository.SaveChanges();
            return Unit.Value;
        }
    }
}