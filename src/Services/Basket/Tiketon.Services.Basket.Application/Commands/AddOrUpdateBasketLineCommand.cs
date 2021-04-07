using System;
using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record AddOrUpdateBasketLineCommand : IRequest<BasketLine>
    {
        public AddOrUpdateBasketLineCommand(Guid basketId, BasketLine basketLine)
        {
            BasketId = basketId;
            BasketLine = basketLine;
        }

        public Guid BasketId { get; }
        public BasketLine BasketLine { get; }
    }
}