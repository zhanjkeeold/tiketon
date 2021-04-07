using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Web.Extensions;
using Tiketon.Web.Models;
using Tiketon.Web.Models.Api;
using Tiketon.Web.Models.View;
using Tiketon.Web.Services;

namespace Tiketon.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IShoppingBasketService _basketService;
        private readonly IDiscountService _discountService;
        private readonly Settings _settings;

        public BasketController(IShoppingBasketService basketService, Settings settings,
            IDiscountService discountService)
        {
            _basketService = basketService;
            _settings = settings;
            _discountService = discountService;
        }

        public async Task<IActionResult> Index()
        {
            var basketViewModel = await CreateBasketViewModel();

            return View(basketViewModel);
        }

        private async Task<BasketViewModel> CreateBasketViewModel()
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            var basket = await _basketService.GetBasket(basketId);

            var basketLines = (await _basketService.GetLinesForBasket(basketId)).ToList();

            var lineViewModels = basketLines.Select(bl => new BasketLineViewModel
            {
                LineId = bl.BasketLineId,
                EventId = bl.EventId,
                EventName = bl.Event.Name,
                Date = bl.Event.Date,
                Price = bl.Price,
                Quantity = bl.TicketAmount
            }).ToList();


            var basketViewModel = new BasketViewModel
            {
                BasketLines = lineViewModels
            };

            Coupon coupon = null;

            if (basket != null && basket.CouponId.HasValue)
                coupon = await _discountService.GetCouponById(basket.CouponId.Value);

            if (coupon != null)
            {
                basketViewModel.Code = coupon.Code;
                basketViewModel.Discount = coupon.Amount;
            }

            basketViewModel.ShoppingCartTotal = basketViewModel.BasketLines.Sum(bl => bl.Price * bl.Quantity);

            return basketViewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLine(BasketLineForCreation basketLine)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            var newLine = await _basketService.AddToBasket(basketId, basketLine);
            Response.Cookies.Append(_settings.BasketIdCookieName, newLine.BasketId.ToString());

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLine(BasketLineForUpdate basketLineUpdate)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            await _basketService.UpdateLine(basketId, basketLineUpdate);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveLine(Guid lineId)
        {
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            await _basketService.RemoveLine(basketId, lineId);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(BasketCheckoutViewModel basketCheckoutViewModel)
        {
            try
            {
                var basketId = Request.Cookies.GetCurrentBasketId(_settings);
                if (ModelState.IsValid)
                {
                    var basketForCheckout = new BasketForCheckout
                    {
                        FirstName = basketCheckoutViewModel.FirstName,
                        LastName = basketCheckoutViewModel.LastName,
                        Email = basketCheckoutViewModel.Email,
                        Address = basketCheckoutViewModel.Address,
                        ZipCode = basketCheckoutViewModel.ZipCode,
                        City = basketCheckoutViewModel.City,
                        Country = basketCheckoutViewModel.Country,
                        CardNumber = basketCheckoutViewModel.CardNumber,
                        CardName = basketCheckoutViewModel.CardName,
                        CardExpiration = basketCheckoutViewModel.CardExpiration,
                        CvvCode = basketCheckoutViewModel.CvvCode,
                        BasketId = basketId,
                        UserId = _settings.UserId
                    };

                    await _basketService.Checkout(basketCheckoutViewModel.BasketId, basketForCheckout);

                    return RedirectToAction("CheckoutComplete");
                }

                return View(basketCheckoutViewModel);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View(basketCheckoutViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplyDiscountCode(string code)
        {
            var coupon = await _discountService.GetCouponByCode(code);

            if (coupon == null || coupon.AlreadyUsed) return RedirectToAction("Index");

            //coupon will be applied to the basket
            var basketId = Request.Cookies.GetCurrentBasketId(_settings);
            await _basketService.ApplyCouponToBasket(basketId, new CouponForUpdate {CouponId = coupon.CouponId});
            await _discountService.UseCoupon(coupon.CouponId);

            return RedirectToAction("Index");
        }

        public IActionResult CheckoutComplete()
        {
            return View();
        }
    }
}