using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using Tiketon.BuildingBlocks.EventBus.Abstractions;
using Tiketon.Services.Basket.Application.Abstractions.Services;
using Tiketon.Services.Basket.Application.Commands;
using Tiketon.Services.Basket.Application.Queries;
using Tiketon.Services.Basket.Controllers.Mappers;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers
{
    [Route("api/baskets")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        // TODO: Refactor, use usecases instead of service and eventbus.
        private readonly IEventBus _eventBus;
        private readonly IMediator _mediator;

        public BasketsController(
            IMediator mediator,
            IEventBus eventBus,
            IDiscountService discountService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
        }

        [ProducesResponseType(typeof(BasketModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet("{basketId}", Name = "GetBasket")]
        public async Task<ActionResult<BasketModel>> Get(Guid basketId)
        {
            var basket = (await _mediator.Send(new GetBasketByIdQuery(basketId)))?.ToModel();
            if (basket == null) return NotFound();

            return Ok(basket);
        }

        [ProducesResponseType(typeof(BasketModel), 200)]
        [HttpPost]
        public async Task<ActionResult<BasketModel>> Post(BasketForCreationModel basketForCreation)
        {
            var basket = basketForCreation.ToDomain();

            await _mediator.Send(new AddBasketCommand(basket));

            var basketToReturn = basket.ToModel();

            return CreatedAtRoute(
                "GetBasket",
                new {basketId = basket.BasketId},
                basketToReturn);
        }

        [HttpPut("{basketId}/coupon")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ApplyCouponToBasket(Guid basketId, CouponModel coupon)
        {
            return await _mediator.Send(new ApplyCouponToBasketCommand(basketId, coupon.CouponId))
                ? Accepted()
                : BadRequest();
        }

        [HttpPost("checkout")]
        [ProducesResponseType((int) HttpStatusCode.Accepted)]
        [ProducesResponseType((int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int) HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CheckoutBasketAsync([FromBody] BasketCheckoutModel basketCheckout)
        {
            try
            {
                var basket = await _mediator.Send(new GetBasketByIdQuery(basketCheckout.BasketId));

                if (basket == null) return BadRequest();

                // TODO: Применить скидку.
                CouponModel coupon = null;

                if (basket.CouponId.HasValue)
                    coupon = (await _discountService.GetCoupon(basket.CouponId.Value))?.ToModel();

                // TODO: Discount with error for check policy.
                //if (basket.CouponId.HasValue)
                //    coupon = await discountService.GetCouponWithError(basket.CouponId.Value);

                var basketCheckoutEvent = basketCheckout.ToEvent(basket.BasketLines, coupon);

                try
                {
                    _eventBus.Publish(basketCheckoutEvent);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                await _mediator.Send(new ClearBasketCommand(basketCheckout.BasketId));
                return Accepted(basketCheckoutEvent);
            }
            catch (BrokenCircuitException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.StackTrace);
            }
        }
    }
}