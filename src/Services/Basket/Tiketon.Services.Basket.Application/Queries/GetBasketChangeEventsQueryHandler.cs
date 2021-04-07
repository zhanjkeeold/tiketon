using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class
        GetBasketChangeEventsQueryHandler : IRequestHandler<GetBasketChangeEventsQuery, List<BasketChangeEvent>>
    {
        private readonly IBasketChangeEventRepository _basketChangeEventRepository;

        public GetBasketChangeEventsQueryHandler(IBasketChangeEventRepository basketChangeEventRepository)
        {
            _basketChangeEventRepository = basketChangeEventRepository ??
                                           throw new ArgumentNullException(nameof(basketChangeEventRepository));
        }

        /// <inheritdoc />
        public Task<List<BasketChangeEvent>> Handle(GetBasketChangeEventsQuery request,
            CancellationToken cancellationToken)
        {
            return _basketChangeEventRepository.GetBasketChangeEvents(request.StartDate, request.Max);
        }
    }
}