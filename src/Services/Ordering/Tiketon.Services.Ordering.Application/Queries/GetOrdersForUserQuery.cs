using System;
using System.Collections.Generic;
using MediatR;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.Queries
{
    public record GetOrdersForUserQuery : IRequest<List<Order>>
    {
        public GetOrdersForUserQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}