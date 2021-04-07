using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public record AddEventCommand : IRequest
    {
        public AddEventCommand(Event theEvent)
        {
            TheEvent = theEvent;
        }

        public Event TheEvent { get; }
    }
}