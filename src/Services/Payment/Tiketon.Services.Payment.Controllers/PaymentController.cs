using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Payment.Application.Commands;
using Tiketon.Services.Payment.Domain;

namespace Tiketon.Services.Payment.Controllers
{
    [ApiController]
    [Route("api/payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // TODO: Метод для проверки.
        [HttpGet]
        public async Task<IActionResult> PerformPayment()
        {
            var paymentInfo = new PaymentInfo
            {
                Total = 1,
                CardExpiration = "2121",
                CardName = "asdasd",
                CardNumber = "1234123412341234"
            };

            await _mediator.Send(new OrderPaymentRequestCommand(paymentInfo));

            return Ok();
        }
    }
}