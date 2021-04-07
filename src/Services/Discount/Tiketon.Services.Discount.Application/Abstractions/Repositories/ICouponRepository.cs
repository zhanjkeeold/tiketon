using System;
using System.Threading;
using System.Threading.Tasks;
using Tiketon.Services.Discount.Domain.Entities;

namespace Tiketon.Services.Discount.Application.Abstractions.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon> GetCouponByCodeAsync(string couponCode, CancellationToken cancellationToken = default);
        Task UseCouponAsync(Guid couponId, CancellationToken cancellationToken = default);
        Task<Coupon> GetCouponByIdAsync(Guid couponId, CancellationToken cancellationToken = default);
    }
}