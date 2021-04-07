using System;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Infrastructure.Persistence
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "Ten",
                Amount = 10,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "Twenty",
                Amount = 20,
                AlreadyUsed = false
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = Guid.NewGuid(),
                Code = "AlmostFree",
                Amount = 100,
                AlreadyUsed = false
            });
        }
    }
}