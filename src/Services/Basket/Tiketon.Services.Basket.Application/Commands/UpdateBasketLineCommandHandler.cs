using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class UpdateBasketLineCommandHandler : IRequestHandler<UpdateBasketLineCommand>
    {
        private readonly IBasketLinesRepository _basketLinesRepository;

        public UpdateBasketLineCommandHandler(IBasketLinesRepository basketLinesRepository)
        {
            _basketLinesRepository =
                basketLinesRepository ?? throw new ArgumentNullException(nameof(basketLinesRepository));
        }

        /// <inheritdoc />
        public async Task<Unit> Handle(UpdateBasketLineCommand request, CancellationToken cancellationToken)
        {
            _basketLinesRepository.UpdateBasketLine(request.BasketLine);
            await _basketLinesRepository.SaveChanges();
            return Unit.Value;
        }
    }
}