using System;
using Microsoft.EntityFrameworkCore;
using Tiketon.Services.Catalog.Domain.Entities;

namespace Tiketon.Services.Catalog.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var theaterGuid = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}");
            var movieGuid = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}");
            var sportGuid = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}");

            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = concertGuid,
                Name = "Концерты"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = theaterGuid,
                Name = "Театры"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = sportGuid,
                Name = "Спорт"
            });
            modelBuilder.Entity<Category>().HasData(new Category
            {
                CategoryId = movieGuid,
                Name = "Фильмы"
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{3448D5A4-0F72-4DD7-BF15-C14A46B26C00}"),
                Name = "«Ne prosto orchestra» представляет: Саундтреки «Наруто» и «Аватар»",
                Price = 8500,
                Artist = "Мадияр Тойболды",
                Date = DateTime.Now.AddMonths(9),
                Description =
                    "Вас ждёт колоссальный живой звук в исполнении симфонического оркестра и смешанного хора под видео ряд из лучших моментов.",
                ImageUrl =
                    "https://ticketon.kz/media/upload/23206u45664_ne-prosto-orchestra-saundtreki-naruto-avatar.jpeg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{B419A7CA-3321-4F38-BE8E-4D7B6A529319}"),
                Name = "David Garrett & band UNLIMITED LIVE 2020",
                Price = 8500,
                Artist = "David Garrett",
                Date = DateTime.Now.AddMonths(4),
                Description =
                    "Паганини среди поп-звезд и Джими Хендрикс среди скрипачей, немецкий скрипач-виртуоз David Garrett - международная суперзвезда, которая стирает границы между Моцартом и группой Metallica.",
                ImageUrl = "https://ticketon.kz/files/media/david-garrett-band-stills.jpg",
                CategoryId = concertGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{62787623-4C52-43FE-B0C9-B7044FB5929B}"),
                Name = "«Легенда о любви» в театре Astana Ballet",
                Price = 2500,
                Artist = "Симон Вирсаладзе",
                Date = DateTime.Now.AddMonths(4),
                Description =
                    "«Легенда о любви» - сказка, корни которой уходят в глубину веков. Она родилась на выжженной солнцем земле Востока и не раз становилась объектом литературных обработок. Зрители впервые увидели спектакль «Легенда о любви» 58 лет назад в Мариинском театре.",
                ImageUrl = "https://ticketon.kz/files/media/legenda-o-lyubvi-v-astana-ballet31023.jpg",
                CategoryId = theaterGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{1BABD057-E980-4CB3-9CD2-7FDD9E525668}"),
                Name = "«Султан Бейбарс» в театре Astana Ballet",
                Price = 4000,
                Artist = "Хамит Шангалиев и Алибек Альпиев",
                Date = DateTime.Now.AddMonths(10),
                Description =
                    "Балет «Султан Бейбарс» - необычайно красивый, поразительно захватывающий рассказ о головокружительном пути к вершинам славы и власти. Такой путь всегда требует жертв во имя служения высшим целям.",
                ImageUrl = "https://ticketon.kz/files/media/sultan-beybarys-astanaballet2021.jpg",
                CategoryId = theaterGuid
            });

            modelBuilder.Entity<Event>().HasData(new Event
            {
                EventId = Guid.Parse("{ADC42C09-08C1-4D2C-9F96-2D15BB1AF299}"),
                Name = "Дина Рубина в Алматы",
                Price = 1350,
                Artist = "Дина Рубина",
                Date = DateTime.Now.AddMonths(8),
                Description =
                    "Мало кто из современных авторов способен читать свои произведения с таким подлинно артистическим мастерством. Два часа пролетают незаметно: Дина Рубина легко держит внимание зала, ее непринужденная интонация, юмор, драматический накал чтения захватывает зрителей и не отпускает до последней минуты встречи.",
                ImageUrl = "https://ticketon.kz/files/media/img-ticketon-101920567164928.jpeg",
                CategoryId = theaterGuid
            });
        }
    }
}