using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByCategoryId(Guid categoryid);
        Task<Event> GetEvent(Guid id);
        Task<IEnumerable<Category>> GetCategories();
    }
}