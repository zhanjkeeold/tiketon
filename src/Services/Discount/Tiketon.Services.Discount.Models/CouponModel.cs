using System;

namespace Tiketon.Services.Discount.Models
{
    public class CouponModel
    {
        public CouponModel()
        {
        }

        public CouponModel(Guid couponId, string code, int amount, bool alreadyUsed)
        {
            CouponId = couponId;
            Code = code;
            Amount = amount;
            AlreadyUsed = alreadyUsed;
        }

        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}