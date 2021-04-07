using System;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Application.Abstractions.Dtos;

namespace Tiketon.Services.Basket.Application.Abstractions.Services
{
    public interface ICatalogService
    {
        Task<EventDto> GetEvent(Guid id);
    }
}