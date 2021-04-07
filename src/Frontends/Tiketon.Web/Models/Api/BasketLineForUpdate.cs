using System;
using System.ComponentModel.DataAnnotations;

namespace Tiketon.Web.Models.Api
{
    public class BasketLineForUpdate
    {
        [Required] public Guid LineId { get; set; }

        [Required] public int TicketAmount { get; set; }
    }
}