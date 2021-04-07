using System.ComponentModel.DataAnnotations;

namespace Tiketon.Services.Basket.Models
{
    public class BasketLineForUpdateModel
    {
        [Required] public int TicketAmount { get; set; }
    }
}