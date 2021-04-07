using System;

namespace Tiketon.Services.Basket.Application.Abstractions.Dtos
{
    public class CouponDto
    {
        public Guid CouponId { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public bool AlreadyUsed { get; set; }
    }
}