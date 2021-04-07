using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersForUser(Guid userId);
        Task<Order> GetOrderDetails(Guid orderId);
    }
}