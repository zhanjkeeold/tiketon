using System;

namespace Tiketon.Services.Basket.Models
{
    public class BasketModel
    {
        public Guid BasketId { get; set; }
        public Guid UserId { get; set; }
        public int NumberOfItems { get; set; }
        public Guid? CouponId { get; set; }
    }
}