using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class AddBasketEventCommandHandler : IRequestHandler<AddBasketEventCommand>
    {
        private readonly IBasketChangeEventRepository _basketChangeEventRepository;

        public AddBasketEventCommandHandler(IBasketChangeEventRepository basketChangeEventRepository)
        {
            _basketChangeEventRepository = basketChangeEventRepository ??
                                           throw new ArgumentNullException(nameof(basketChangeEventRepository));
        }

        public Task<Unit> Handle(AddBasketEventCommand request, CancellationToken cancellationToken)
        {
            _basketChangeEventRepository.AddBasketEvent(request.BasketChangeEvent);
            return Unit.Task;
        }
    }
}