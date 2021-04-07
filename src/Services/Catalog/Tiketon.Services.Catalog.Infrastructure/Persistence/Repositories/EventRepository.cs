using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Catalog.Application.Abstractions.Repositories;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Infrastructure.Persistence.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly CatalogDbContext _catalogDbContext;

        public EventRepository(CatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }

        public async Task<IEnumerable<Event>> GetEvents(Guid categoryId)
        {
            return await _catalogDbContext.Events
                .Include(x => x.Category)
                .Where(x => x.CategoryId == categoryId || categoryId == Guid.Empty).ToListAsync();
        }

        public async Task<Event> GetEventById(Guid eventId)
        {
            return await _catalogDbContext.Events.Include(x => x.Category).Where(x => x.EventId == eventId)
                .FirstOrDefaultAsync();
        }
    }
}