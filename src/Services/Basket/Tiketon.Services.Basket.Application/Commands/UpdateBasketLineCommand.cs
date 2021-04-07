using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record UpdateBasketLineCommand : IRequest
    {
        public UpdateBasketLineCommand(BasketLine basketLine)
        {
            BasketLine = basketLine;
        }

        public BasketLine BasketLine { get; }
    }
}