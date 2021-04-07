using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Ordering.Domain.Entities;

namespace Tiketon.Services.Ordering.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}