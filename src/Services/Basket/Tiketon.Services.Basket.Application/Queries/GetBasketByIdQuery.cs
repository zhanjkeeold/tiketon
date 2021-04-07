using System;
using MediatR;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record GetBasketByIdQuery : IRequest<Domain.Entities.Basket>
    {
        public GetBasketByIdQuery(Guid basketId)
        {
            BasketId = basketId;
        }

        public Guid BasketId { get; }
    }
}