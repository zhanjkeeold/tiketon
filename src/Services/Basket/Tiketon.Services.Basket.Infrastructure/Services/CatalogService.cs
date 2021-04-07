using System;
using System.Net.Http;
using System.Threading.Tasks;
using Tiketon.Services.Basket.Application.Abstractions.Dtos;
using Tiketon.Services.Basket.Application.Abstractions.Services;
using Tiketon.Services.Basket.Infrastructure.Extensions;

namespace Tiketon.Services.Basket.Infrastructure.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<EventDto> GetEvent(Guid id)
        {
            var response = await _client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<EventDto>();
        }
    }
}