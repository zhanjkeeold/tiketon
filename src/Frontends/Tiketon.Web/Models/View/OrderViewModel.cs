using System.Collections.Generic;
using Tiketon.Web.Models.Api;

namespace Tiketon.Web.Models.View
{
    public class OrderViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}