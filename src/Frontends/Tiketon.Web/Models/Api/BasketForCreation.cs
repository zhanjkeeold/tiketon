using System;
using System.ComponentModel.DataAnnotations;

namespace Tiketon.Web.Models.Api
{
    public class BasketForCreation
    {
        [Required] public Guid UserId { get; set; }
    }
}