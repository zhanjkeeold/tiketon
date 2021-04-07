using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Web.Extensions;
using Tiketon.Web.Models;
using Tiketon.Web.Models.Api;
using Tiketon.Web.Models.View;
using Tiketon.Web.Services;

namespace Tiketon.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly Settings _settings;
        private readonly IShoppingBasketService _shoppingBasketService;

        public CatalogController(ICatalogService catalogService,
            IShoppingBasketService shoppingBasketService, Settings settings)
        {
            _catalogService = catalogService;
            _shoppingBasketService = shoppingBasketService;
            _settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(_settings);

            var getBasket = currentBasketId == Guid.Empty
                ? Task.FromResult<Basket>(null)
                : _shoppingBasketService.GetBasket(currentBasketId);

            var getCategories = _catalogService.GetCategories();

            var getEvents = categoryId == Guid.Empty
                ? _catalogService.GetAll()
                : _catalogService.GetByCategoryId(categoryId);

            await Task.WhenAll(getBasket, getCategories, getEvents);

            var numberOfItems = getBasket.Result?.NumberOfItems ?? 0;

            return View(
                new EventListModel
                {
                    Events = getEvents.Result,
                    Categories = getCategories.Result,
                    NumberOfItems = numberOfItems,
                    SelectedCategory = categoryId
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm] Guid selectedCategory)
        {
            return RedirectToAction("Index", new {categoryId = selectedCategory});
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await _catalogService.GetEvent(eventId);
            return View(ev);
        }
    }
}