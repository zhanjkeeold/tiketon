using System;
using System.ComponentModel.DataAnnotations;

namespace Tiketon.Web.Models.Api
{
    public class CouponForUpdate
    {
        [Required] public Guid CouponId { get; set; }
    }
}