using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tiketon.Services.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
    {
        public CatalogDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=(local);Database=tiketon_catalog;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CatalogDbContext(optionsBuilder.Options);
        }
    }
}