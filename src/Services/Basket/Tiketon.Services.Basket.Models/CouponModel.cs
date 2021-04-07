using System;

namespace Tiketon.Services.Basket.Models
{
    public class CouponModel
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}