using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Queries
{
    public class EventExistsQueryHandler : IRequestHandler<EventExistsQuery, bool>
    {
        private readonly IEventRepository _eventRepository;

        public EventExistsQueryHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ??
                               throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public Task<bool> Handle(EventExistsQuery request, CancellationToken cancellationToken)
        {
            return _eventRepository.EventExists(request.EventId);
        }
    }
}