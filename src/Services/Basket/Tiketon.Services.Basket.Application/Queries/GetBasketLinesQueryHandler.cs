using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class GetBasketLinesQueryHandler : IRequestHandler<GetBasketLinesQuery, IEnumerable<BasketLine>>
    {
        private readonly IBasketLinesRepository _basketLinesRepository;

        public GetBasketLinesQueryHandler(IBasketLinesRepository basketLinesRepository)
        {
            _basketLinesRepository =
                basketLinesRepository ?? throw new ArgumentNullException(nameof(basketLinesRepository));
        }

        /// <inheritdoc />
        public Task<IEnumerable<BasketLine>> Handle(GetBasketLinesQuery request, CancellationToken cancellationToken)
        {
            return _basketLinesRepository.GetBasketLines(request.BasketId);
        }
    }
}