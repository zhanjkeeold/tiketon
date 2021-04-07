using System;
using MediatR;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record ClearBasketCommand : IRequest
    {
        public ClearBasketCommand(Guid basketId)
        {
            BasketId = basketId;
        }

        public Guid BasketId { get; }
    }
}