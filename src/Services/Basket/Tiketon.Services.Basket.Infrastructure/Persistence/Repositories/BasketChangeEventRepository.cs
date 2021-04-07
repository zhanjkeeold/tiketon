using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Repositories
{
    public class BasketChangeEventRepository : IBasketChangeEventRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketChangeEventRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public async Task AddBasketEvent(BasketChangeEvent basketChangeEvent)
        {
            await _basketDbContext.BasketChangeEvents.AddAsync(basketChangeEvent);
            await _basketDbContext.SaveChangesAsync();
        }

        public async Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max)
        {
            return await _basketDbContext.BasketChangeEvents.Where(b => b.InsertedAt > startDate)
                .OrderBy(b => b.InsertedAt).Take(max).ToListAsync();
        }
    }
}