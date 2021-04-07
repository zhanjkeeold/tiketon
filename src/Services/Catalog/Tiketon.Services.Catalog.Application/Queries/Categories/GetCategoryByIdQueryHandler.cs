using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiketon.Services.Catalog.Application.Abstractions.Repositories;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Application.Queries.Categories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        /// <inheritdoc />
        public Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return _categoryRepository.GetCategoryById(request.CategoryId);
        }
    }
}