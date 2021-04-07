using System;
using System.ComponentModel.DataAnnotations;

namespace Tiketon.Services.Basket.Models
{
    public class BasketForCreationModel
    {
        [Required] public Guid UserId { get; set; }
    }
}