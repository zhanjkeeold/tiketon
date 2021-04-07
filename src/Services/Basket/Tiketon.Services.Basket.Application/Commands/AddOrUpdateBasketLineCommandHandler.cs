using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Commands
{
    public class AddOrUpdateBasketLineCommandHandler : IRequestHandler<AddOrUpdateBasketLineCommand, BasketLine>
    {
        private readonly IBasketLinesRepository _basketLinesRepository;

        public AddOrUpdateBasketLineCommandHandler(IBasketLinesRepository basketLinesRepository)
        {
            _basketLinesRepository =
                basketLinesRepository ?? throw new ArgumentNullException(nameof(basketLinesRepository));
        }

        /// <inheritdoc />
        public async Task<BasketLine> Handle(AddOrUpdateBasketLineCommand request, CancellationToken cancellationToken)
        {
            var basketLine = await _basketLinesRepository.AddOrUpdateBasketLine(request.BasketId, request.BasketLine);
            await _basketLinesRepository.SaveChanges();

            return basketLine;
        }
    }
}