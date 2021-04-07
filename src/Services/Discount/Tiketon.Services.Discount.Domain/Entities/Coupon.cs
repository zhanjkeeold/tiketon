using System;

namespace Tiketon.Services.Discount.Domain.Entities
{
    public class Coupon
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }

        public void Used()
        {
            AlreadyUsed = true;
        }
    }
}