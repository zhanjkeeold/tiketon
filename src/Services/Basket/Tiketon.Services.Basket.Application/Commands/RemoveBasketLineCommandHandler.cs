using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class RemoveBasketLineCommandHandler : IRequestHandler<RemoveBasketLineCommand>
    {
        private readonly IBasketLinesRepository _basketLinesRepository;

        public RemoveBasketLineCommandHandler(IBasketLinesRepository basketLinesRepository)
        {
            _basketLinesRepository =
                basketLinesRepository ?? throw new ArgumentNullException(nameof(basketLinesRepository));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(RemoveBasketLineCommand request, CancellationToken cancellationToken)
        {
            _basketLinesRepository.RemoveBasketLine(request.BasketLine);
            await _basketLinesRepository.SaveChanges();
            return Unit.Value;
        }
    }
}