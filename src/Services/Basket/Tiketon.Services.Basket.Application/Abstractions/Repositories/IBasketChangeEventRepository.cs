using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Abstractions.Repositories
{
    public interface IBasketChangeEventRepository
    {
        Task AddBasketEvent(BasketChangeEvent basketChangeEvent);
        Task<List<BasketChangeEvent>> GetBasketChangeEvents(DateTime startDate, int max);
    }
}