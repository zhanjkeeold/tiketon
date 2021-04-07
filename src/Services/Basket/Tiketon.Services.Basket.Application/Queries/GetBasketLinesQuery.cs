using System;
using System.Collections.Generic;
using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record GetBasketLinesQuery : IRequest<IEnumerable<BasketLine>>
    {
        public GetBasketLinesQuery(Guid basketId)
        {
            BasketId = basketId;
        }

        public Guid BasketId { get; }
    }
}