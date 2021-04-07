using System;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Abstractions.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event theEvent);
        Task<bool> EventExists(Guid eventId);
        Task<bool> SaveChanges();
    }
}