using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;

namespace Tiketon.Services.Ordering.Application.Commands
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository));
        }

        /// <inheritdoc />
        public Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            _orderRepository.AddOrder(request.Order);
            return Unit.Task;
        }
    }
}