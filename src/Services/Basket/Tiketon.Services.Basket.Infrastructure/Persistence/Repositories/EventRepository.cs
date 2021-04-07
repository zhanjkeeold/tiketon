using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Basket.Application.Abstractions.Repositories;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public EventRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public async Task<bool> EventExists(Guid eventId)
        {
            return await _basketDbContext.Events.AnyAsync(e => e.EventId == eventId);
        }

        public void AddEvent(Event theEvent)
        {
            _basketDbContext.Events.Add(theEvent);
        }

        public async Task<bool> SaveChanges()
        {
            return await _basketDbContext.SaveChangesAsync() > 0;
        }
    }
}