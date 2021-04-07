using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;

        public AddBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ??
                                throw new ArgumentNullException(nameof(basketRepository));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(AddBasketCommand request, CancellationToken cancellationToken)
        {
            _basketRepository.AddBasket(request.Basket);
            await _basketRepository.SaveChanges();
            return Unit.Value;
        }
    }
}