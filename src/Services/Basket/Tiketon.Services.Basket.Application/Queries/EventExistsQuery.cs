using System;
using MediatR;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record EventExistsQuery : IRequest<bool>
    {
        public EventExistsQuery(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; }
    }
}