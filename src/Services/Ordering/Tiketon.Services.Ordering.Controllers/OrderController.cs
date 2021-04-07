using System;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Ordering.Application.Queries;
using Tiketon.Services.Ordering.Controllers.Mappers;
using Tiketon.Services.Ordering.Models;

namespace Tiketon.Services.Ordering.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(OrderModel), 200)]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> List(Guid userId)
        {
            return Ok((await _mediator.Send(new GetOrdersForUserQuery(userId)))
                ?.Select(x => x?.ToModel())
                .ToList());
        }
    }
}