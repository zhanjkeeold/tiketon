using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Catalog.Application.Abstractions.Repositories;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Events
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Event>
    {
        private readonly IEventRepository _eventRepository;

        public GetEventByIdQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public Task<Event> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            return _eventRepository.GetEventById(request.EventId);
        }
    }
}