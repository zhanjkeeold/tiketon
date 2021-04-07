using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Tiketon.Web.Extensions;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Order>> GetOrdersForUser(Guid userId)
        {
            var response = await _client.GetAsync($"/api/order/user/{userId}");
            return await response.ReadContentAs<List<Order>>();
        }

        public async Task<Order> GetOrderDetails(Guid orderId)
        {
            var response = await _client.GetAsync($"/api/order/{orderId}");
            return await response.ReadContentAs<Order>();
        }
    }
}