using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Infrastructure.Persistence
{
    public class BasketDbContext : DbContext
    {
        public BasketDbContext(DbContextOptions<BasketDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Entities.Basket> Baskets { get; set; }
        public DbSet<BasketLine> BasketLines { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<BasketChangeEvent> BasketChangeEvents { get; set; }
    }
}