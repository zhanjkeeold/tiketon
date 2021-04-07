using System;
using System.Threading.Tasks;

namespace Tiketon.Services.Basket.Application.Abstractions.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<Domain.Entities.Basket> GetBasketById(Guid basketId);

        void AddBasket(Domain.Entities.Basket basket);

        Task<bool> SaveChanges();

        Task ClearBasket(Guid basketId);
    }
}