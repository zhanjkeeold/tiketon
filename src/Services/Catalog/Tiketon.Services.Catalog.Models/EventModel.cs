using System;

namespace Tiketon.Services.Catalog.Models
{
    public class EventModel
    {
        public EventModel(Guid eventId, string name, int price, string artist, DateTime date, string description,
            string imageUrl, Guid categoryId, string categoryName)
        {
            EventId = eventId;
            Name = name;
            Price = price;
            Artist = artist;
            Date = date;
            Description = description;
            ImageUrl = imageUrl;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Guid EventId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}