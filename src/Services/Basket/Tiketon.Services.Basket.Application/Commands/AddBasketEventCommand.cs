using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record AddBasketEventCommand : IRequest
    {
        public AddBasketEventCommand(BasketChangeEvent basketChangeEvent)
        {
            BasketChangeEvent = basketChangeEvent;
        }

        public BasketChangeEvent BasketChangeEvent { get; }
    }
}