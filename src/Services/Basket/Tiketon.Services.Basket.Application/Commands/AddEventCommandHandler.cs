using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class AddEventCommandHandler : IRequestHandler<AddEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public AddEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ??
                               throw new ArgumentNullException(nameof(eventRepository));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            _eventRepository.AddEvent(request.TheEvent);
            await _eventRepository.SaveChanges();
            return Unit.Value;
        }
    }
}