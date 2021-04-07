using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record RemoveBasketLineCommand : IRequest
    {
        public RemoveBasketLineCommand(BasketLine basketLine)
        {
            BasketLine = basketLine;
        }

        public BasketLine BasketLine { get; }
    }
}