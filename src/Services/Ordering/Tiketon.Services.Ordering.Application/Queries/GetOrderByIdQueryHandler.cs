using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository));
        }

        /// <inheritdoc />
        public Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrderById(request.OrderId);
        }
    }
}