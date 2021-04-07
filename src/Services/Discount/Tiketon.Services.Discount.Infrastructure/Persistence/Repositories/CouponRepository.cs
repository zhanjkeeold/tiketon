using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Discount.Application.Abstractions.Repositories;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Infrastructure.Persistence.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountDbContext _discountDbContext;

        public CouponRepository(DiscountDbContext discountDbContext)
        {
            _discountDbContext = discountDbContext;
        }

        public async Task<Coupon> GetCouponByCodeAsync(string couponCode, CancellationToken cancellationToken = default)
        {
            return await _discountDbContext.Coupons.Where(x => x.Code == couponCode)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UseCouponAsync(Guid couponId, CancellationToken cancellationToken = default)
        {
            var couponToUpdate =
                await _discountDbContext.Coupons.Where(x => x.CouponId == couponId)
                    .FirstOrDefaultAsync(cancellationToken);

            if (couponToUpdate == null) throw new Exception($"Coupon not found by id: {couponId}");

            couponToUpdate.Used();
            await _discountDbContext.SaveChangesAsync();
        }

        public async Task<Coupon> GetCouponByIdAsync(Guid couponId, CancellationToken cancellationToken = default)
        {
            return await _discountDbContext.Coupons.Where(x => x.CouponId == couponId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}