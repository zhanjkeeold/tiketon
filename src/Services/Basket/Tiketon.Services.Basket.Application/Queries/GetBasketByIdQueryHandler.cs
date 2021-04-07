using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, Domain.Entities.Basket>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketByIdQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ??
                                throw new ArgumentNullException(nameof(basketRepository));
        }

        /// <inheritdoc />
        public Task<Domain.Entities.Basket> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            return _basketRepository.GetBasketById(request.BasketId);
        }
    }
}