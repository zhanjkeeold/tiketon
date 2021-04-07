using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Basket.Application.Abstractions.Services;
using Tiketon.Services.Basket.Application.Commands;
using Tiketon.Services.Basket.Application.Mappers;
using Tiketon.Services.Basket.Application.Queries;
using Tiketon.Services.Basket.Controllers.Mappers;
using Tiketon.Services.Basket.Domain.Entities;
using Tiketon.Services.Basket.Domain.Enums;
using Tiketon.Services.Basket.Models;

namespace Tiketon.Services.Basket.Controllers
{
    [Route("api/baskets/{basketId}/basketlines")]
    [ApiController]
    public class BasketLinesController : ControllerBase
    {
        // TODO: Refactor this, use use cases instead of service
        private readonly ICatalogService _catalogService;
        private readonly IMediator _mediator;

        public BasketLinesController(IMediator mediator, ICatalogService catalogService)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        [ProducesResponseType(typeof(IEnumerable<BasketLineModel>), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasketLineModel>>> Get(Guid basketId)
        {
            if (!await _mediator.Send(new BasketExistsQuery(basketId)))
                return NotFound();

            return Ok((await _mediator.Send(new GetBasketLinesQuery(basketId)))
                ?.Select(x => x?.ToModel())
                .ToList());
        }

        [ProducesResponseType(typeof(BasketLineModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpGet("{basketLineId}", Name = "GetBasketLine")]
        public async Task<ActionResult<BasketLineModel>> Get(Guid basketId,
            Guid basketLineId)
        {
            if (!await _mediator.Send(new BasketExistsQuery(basketId))) return NotFound();

            var basketLine = await _mediator.Send(new GetBasketLineByIdQuery(basketLineId));
            if (basketLine == null) return NotFound();

            return Ok(basketLine.ToModel());
        }

        [ProducesResponseType(typeof(BasketLineModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpPost]
        public async Task<ActionResult<BasketLineModel>> Post(Guid basketId,
            [FromBody] BasketLineForCreationModel basketLineForCreation)
        {
            var basket = await _mediator.Send(new GetBasketByIdQuery(basketId));

            if (basket == null) return NotFound();

            if (!await _mediator.Send(new EventExistsQuery(basketLineForCreation.EventId)))
            {
                var eventFromCatalog = await _catalogService.GetEvent(basketLineForCreation.EventId);
                await _mediator.Send(new AddEventCommand(eventFromCatalog.ToDomain()));
            }

            var basketLineEntity = basketLineForCreation.ToDomain();

            var processedBasketLine =
                await _mediator.Send(new AddOrUpdateBasketLineCommand(basketId, basketLineEntity));

            var basketLineToReturn = processedBasketLine.ToModel();

            var basketChangeEvent = new BasketChangeEvent
            {
                BasketChangeType = BasketChangeTypeEnum.Add,
                EventId = basketLineForCreation.EventId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await _mediator.Send(new AddBasketEventCommand(basketChangeEvent));

            return CreatedAtRoute(
                "GetBasketLine",
                new {basketId = basketLineEntity.BasketId, basketLineId = basketLineEntity.BasketLineId},
                basketLineToReturn);
        }

        [ProducesResponseType(typeof(BasketLineModel), 200)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [HttpPut("{basketLineId}")]
        public async Task<ActionResult<BasketLineModel>> Put(Guid basketId,
            Guid basketLineId,
            [FromBody] BasketLineForUpdateModel basketLineForUpdate)
        {
            if (!await _mediator.Send(new BasketExistsQuery(basketId)))
                return NotFound();

            var basketLine = await _mediator.Send(new GetBasketLineByIdQuery(basketLineId));

            if (basketLine == null) return NotFound();

            basketLine.SetTicketAmount(basketLineForUpdate.TicketAmount);

            await _mediator.Send(new UpdateBasketLineCommand(basketLine));

            return Ok(basketLine.ToModel());
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        [HttpDelete("{basketLineId}")]
        public async Task<IActionResult> Delete(Guid basketId, Guid basketLineId)
        {
            //if (!await _mediator.Send(new BasketExistsQuery(basketId))) return NotFound();

            var basket = await _mediator.Send(new GetBasketByIdQuery(basketId));

            if (basket == null) return NotFound();

            var basketLine = await _mediator.Send(new GetBasketLineByIdQuery(basketLineId));

            if (basketLine == null) return NotFound();

            await _mediator.Send(new RemoveBasketLineCommand(basketLine));

            // Публикуем удаленные позиции.
            var basketChangeEvent = new BasketChangeEvent
            {
                BasketChangeType = BasketChangeTypeEnum.Remove,
                EventId = basketLine.EventId,
                InsertedAt = DateTime.Now,
                UserId = basket.UserId
            };
            await _mediator.Send(new AddBasketEventCommand(basketChangeEvent));

            return NoContent();
        }
    }
}