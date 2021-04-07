using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Basket.Application.Queries;
using Tiketon.Services.Basket.Controllers.Mappers;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers
{
    [ApiController]
    [Route("api/basketevent")]
    public class BasketChangeEventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketChangeEventController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(IEnumerable<BasketChangeEventForPublicationModel>), 200)]
        [HttpGet]
        public async Task<IActionResult> GetEvents([FromQuery] DateTime fromDate, [FromQuery] int max)
        {
            return Ok((await _mediator.Send(new GetBasketChangeEventsQuery(fromDate, max)))
                .Select(x => x.ToModel())
                .ToList());
        }
    }
}