using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Catalog.Application.Queries.Events;
using Tiketon.Services.Catalog.Domain.Entities;
using Tiketon.Services.Catalog.Models;

namespace Tiketon.Services.Catalog.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(IEnumerable<EventModel>), 200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventModel>>> Get(
            [FromQuery] Guid categoryId)
        {
            return Ok((await _mediator.Send(new GetAllEventsQuery(categoryId))).Select(ToModel).ToList());
        }

        [ProducesResponseType(typeof(EventModel), 200)]
        [HttpGet("{eventId}")]
        public async Task<ActionResult<EventModel>> GetById(Guid eventId)
        {
            return Ok(
                ToModel(
                    await _mediator.Send(new GetEventByIdQuery(eventId))));
        }

        private static EventModel ToModel(Event source)
        {
            if (source is null) return null;

            return new EventModel(source.EventId,
                source.Name,
                source.Price,
                source.Artist,
                source.Date,
                source.Description,
                source.ImageUrl,
                source.CategoryId,
                source.Category?.Name);
        }
    }
}