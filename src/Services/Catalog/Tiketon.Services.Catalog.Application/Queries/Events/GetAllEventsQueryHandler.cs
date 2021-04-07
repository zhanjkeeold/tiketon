using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Catalog.Application.Abstractions.Repositories;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Events
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<Event>>
    {
        private readonly IEventRepository _eventRepository;

        public GetAllEventsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public Task<IEnumerable<Event>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            return _eventRepository.GetEvents(request.CategoryId);
        }
    }
}