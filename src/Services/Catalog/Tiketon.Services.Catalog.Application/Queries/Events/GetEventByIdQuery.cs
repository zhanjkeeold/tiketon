using System;
using MediatR;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Events
{
    public record GetEventByIdQuery : IRequest<Event>
    {
        public GetEventByIdQuery(Guid eventId)
        {
            EventId = eventId;
        }

        public Guid EventId { get; }
    }
}