using System;

namespace Tiketon.Services.Catalog.Models
{
    public class CategoryModel
    {
        public CategoryModel(Guid categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }

        public Guid CategoryId { get; set; }
        public string Name { get; set; }
    }
}