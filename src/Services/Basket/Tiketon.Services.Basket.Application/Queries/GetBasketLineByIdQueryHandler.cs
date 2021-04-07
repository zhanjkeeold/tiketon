using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class GetBasketLineByIdQueryHandler : IRequestHandler<GetBasketLineByIdQuery, BasketLine>
    {
        private readonly IBasketLinesRepository _basketLinesRepository;

        public GetBasketLineByIdQueryHandler(IBasketLinesRepository basketLinesRepository)
        {
            _basketLinesRepository =
                basketLinesRepository ?? throw new ArgumentNullException(nameof(basketLinesRepository));
        }

        /// <inheritdoc />
        public Task<BasketLine> Handle(GetBasketLineByIdQuery request, CancellationToken cancellationToken)
        {
            return _basketLinesRepository.GetBasketLineById(request.BasketLineId);
        }
    }
}