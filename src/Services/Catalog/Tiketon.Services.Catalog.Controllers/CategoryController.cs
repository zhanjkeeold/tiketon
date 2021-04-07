using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tiketon.Services.Catalog.Application.Queries.Categories;
using Tiketon.Services.Catalog.Domain.Entities;
using Tiketon.Services.Catalog.Models;

namespace Tiketon.Services.Catalog.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [ProducesResponseType(typeof(IEnumerable<CategoryModel>), 200)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> Get()
        {
            return Ok((await _mediator.Send(new GetAllCategoriesQuery())).Select(ToModel).ToList());
        }

        private static CategoryModel ToModel(Category source)
        {
            return source is null ? null : new CategoryModel(source.CategoryId, source.Name);
        }
    }
}