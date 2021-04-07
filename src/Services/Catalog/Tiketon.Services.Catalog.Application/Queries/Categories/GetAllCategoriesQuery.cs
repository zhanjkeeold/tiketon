using System.Collections.Generic;
using MediatR;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Categories
{
    public record GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}