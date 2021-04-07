using MediatR;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.Commands
{
    public record AddOrderCommand : IRequest
    {
        public AddOrderCommand(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
    }
}