using System;

namespace Tiketon.Services.Basket.Models
{
    public class BasketChangeEventForPublicationModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public BasketChangeTypeModel BasketChangeTypeModel { get; set; }
    }
}