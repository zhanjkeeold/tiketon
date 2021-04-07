using System;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Discount.Application.Commands.Coupons;
using Tiketon.Services.Discount.Application.Queries.Coupons;
using Tiketon.Services.Discount.Controllers.Mappers;
using Tiketon.Services.Discount.Models;

namespace Tiketon.Services.Discount.Controllers
{
    [ApiController]
    [Route("api/discount")]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(CouponModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet("code/{code}")]
        public async Task<ActionResult<CouponModel>> GetDiscountForCode(string code)
        {
            var coupon = await _mediator.Send(new GetCouponByCodeQuery(code));

            if (coupon is null) return NotFound();

            return Ok(coupon.ToModel());
        }

        [ProducesResponseType(typeof(CouponModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet("{couponId}")]
        public async Task<ActionResult<CouponModel>> GetDiscountForCode(Guid couponId)
        {
            var coupon = await _mediator.Send(new GetCouponByIdQuery(couponId));

            if (coupon is null) return NotFound();

            return Ok(coupon.ToModel());
        }

        [HttpPut("use/{couponId}")]
        public async Task<IActionResult> UseCoupon(Guid couponId)
        {
            await _mediator.Send(new UseCouponCommand(couponId));
            return Ok();
        }

        // Используется для проверки политик Polly.
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet("error/{couponId}")]
        public async Task<IActionResult> GetDiscountForCode2(Guid couponId)
        {
            return await Task.Run(() => new StatusCodeResult(StatusCodes.Status500InternalServerError));
        }
    }
}