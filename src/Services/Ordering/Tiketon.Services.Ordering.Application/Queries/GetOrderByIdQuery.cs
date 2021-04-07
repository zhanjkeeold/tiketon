using System;
using MediatR;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.Queries
{
    public record GetOrderByIdQuery : IRequest<Order>
    {
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}