using MediatR;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Categories
{
    public record GetCategoryByIdQuery : IRequest<Category>
    {
        public GetCategoryByIdQuery(string categoryId)
        {
            CategoryId = categoryId;
        }

        public string CategoryId { get; }
    }
}