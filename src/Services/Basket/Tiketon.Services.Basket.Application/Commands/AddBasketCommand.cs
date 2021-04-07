using MediatR;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record AddBasketCommand : IRequest
    {
        public AddBasketCommand(Domain.Entities.Basket basket)
        {
            Basket = basket;
        }

        public Domain.Entities.Basket Basket { get; }
    }
}