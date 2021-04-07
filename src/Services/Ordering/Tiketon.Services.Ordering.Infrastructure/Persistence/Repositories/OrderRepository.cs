using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Ordering.Application.Abstractions.Repositories;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<OrderDbContext> _dbContextOptions;

        public OrderRepository(DbContextOptions<OrderDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions ?? throw new ArgumentNullException(nameof(dbContextOptions));
        }

        public async Task<List<Order>> GetOrdersForUser(Guid userId)
        {
            await using var orderDbContext = new OrderDbContext(_dbContextOptions);
            return await orderDbContext.Orders.Where(o => o.UserId == userId).OrderBy(o => o.OrderPlaced)
                .ToListAsync();
        }

        public async Task AddOrder(Order order)
        {
            await using var orderDbContext = new OrderDbContext(_dbContextOptions);
            await orderDbContext.Orders.AddAsync(order);
            await orderDbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            await using var orderDbContext = new OrderDbContext(_dbContextOptions);
            return await orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
        }

        public async Task UpdateOrderPaymentStatus(Guid orderId, bool paid)
        {
            await using var orderDbContext = new OrderDbContext(_dbContextOptions);
            var order = await orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
            order.OrderPaid = paid;
            await orderDbContext.SaveChangesAsync();
        }
    }
}