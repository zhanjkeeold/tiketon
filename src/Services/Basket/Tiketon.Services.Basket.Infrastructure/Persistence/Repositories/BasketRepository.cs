using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public async Task<Domain.Entities.Basket> GetBasketById(Guid basketId)
        {
            return await _basketDbContext.Baskets.Include(sb => sb.BasketLines)
                .Where(b => b.BasketId == basketId).FirstOrDefaultAsync();
        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            return await _basketDbContext.Baskets
                .AnyAsync(b => b.BasketId == basketId);
        }

        public async Task ClearBasket(Guid basketId)
        {
            var basketLinesToClear = _basketDbContext.BasketLines.Where(b => b.BasketId == basketId);
            _basketDbContext.BasketLines.RemoveRange(basketLinesToClear);

            var basket = _basketDbContext.Baskets.FirstOrDefault(b => b.BasketId == basketId);
            if (basket != null) basket.CouponId = null;

            await SaveChanges();
        }

        public void AddBasket(Domain.Entities.Basket basket)
        {
            _basketDbContext.Baskets.Add(basket);
        }

        public async Task<bool> SaveChanges()
        {
            return await _basketDbContext.SaveChangesAsync() > 0;
        }
    }
}