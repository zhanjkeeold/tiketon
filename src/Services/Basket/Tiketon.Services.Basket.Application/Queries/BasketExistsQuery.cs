using System;
using MediatR;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record BasketExistsQuery : IRequest<bool>
    {
        public BasketExistsQuery(Guid basketId)
        {
            BasketId = basketId;
        }

        public Guid BasketId { get; }
    }
}