using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Web.Models;
using Tiketon.Web.Models.View;
using Tiketon.Web.Services;

namespace Tiketon.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly Settings _settings;

        public OrderController(Settings settings, IOrderService orderService)
        {
            _settings = settings;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetOrdersForUser(_settings.UserId);

            return View(new OrderViewModel {Orders = orders});
        }
    }
}