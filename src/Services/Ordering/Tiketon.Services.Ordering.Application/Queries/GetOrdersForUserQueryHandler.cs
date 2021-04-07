using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Application.Queries
{
    public class GetOrdersForUserQueryHandler : IRequestHandler<GetOrdersForUserQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersForUserQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ??
                               throw new ArgumentNullException(nameof(orderRepository));
        }

        /// <inheritdoc />
        public Task<List<Order>> Handle(GetOrdersForUserQuery request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersForUser(request.UserId);
        }
    }
}