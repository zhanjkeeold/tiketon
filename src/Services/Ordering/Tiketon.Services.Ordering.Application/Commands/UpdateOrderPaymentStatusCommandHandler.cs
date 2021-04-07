using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;

namespace Tiketon.Services.Ordering.Application.Commands
{
    public class UpdateOrderPaymentStatusCommandHandler : IRequestHandler<UpdateOrderPaymentStatusCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderPaymentStatusCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository));
        }

        /// <inheritdoc />
        public Task<Unit> Handle(UpdateOrderPaymentStatusCommand request, CancellationToken cancellationToken)
        {
            _orderRepository.UpdateOrderPaymentStatus(request.OrderId, request.Paid);
            return Unit.Task;
        }
    }
}