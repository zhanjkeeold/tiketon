using System;
using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record GetBasketLineByIdQuery : IRequest<BasketLine>
    {
        public GetBasketLineByIdQuery(Guid basketLineId)
        {
            BasketLineId = basketLineId;
        }

        public Guid BasketLineId { get; }
    }
}