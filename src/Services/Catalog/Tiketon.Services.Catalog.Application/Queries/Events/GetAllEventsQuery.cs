using System;
using System.Collections.Generic;
using MediatR;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Events
{
    public record GetAllEventsQuery : IRequest<IEnumerable<Event>>
    {
        public GetAllEventsQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }

        public Guid CategoryId { get; }
    }
}