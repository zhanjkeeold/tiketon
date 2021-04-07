using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class BasketExistsQueryHandler : IRequestHandler<BasketExistsQuery, bool>
    {
        private readonly IBasketRepository _basketRepository;

        public BasketExistsQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ??
                                throw new ArgumentNullException(nameof(basketRepository));
        }

        /// <inheritdoc />
        public Task<bool> Handle(BasketExistsQuery request, CancellationToken cancellationToken)
        {
            return _basketRepository.BasketExists(request.BasketId);
        }
    }
}