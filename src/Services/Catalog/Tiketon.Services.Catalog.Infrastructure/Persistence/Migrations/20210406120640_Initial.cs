using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Catalog.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Categories",
                table => new
                {
                    CategoryId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Categories", x => x.CategoryId); });

            migrationBuilder.CreateTable(
                "Events",
                table => new
                {
                    EventId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Price = table.Column<int>("int", nullable: false),
                    Artist = table.Column<string>("nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>("datetime2", nullable: false),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>("nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>("uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        "FK_Events_Categories_CategoryId",
                        x => x.CategoryId,
                        "Categories",
                        "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Categories",
                new[] {"CategoryId", "Name"},
                new object[,]
                {
                    {new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Концерты"},
                    {new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Театры"},
                    {new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), "Спорт"},
                    {new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Фильмы"}
                });

            migrationBuilder.InsertData(
                "Events",
                new[] {"EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price"},
                new object[,]
                {
                    {
                        new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "Мадияр Тойболды",
                        new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                        new DateTime(2022, 1, 6, 18, 6, 39, 571, DateTimeKind.Local).AddTicks(8709),
                        "Вас ждёт колоссальный живой звук в исполнении симфонического оркестра и смешанного хора под видео ряд из лучших моментов.",
                        "https://ticketon.kz/media/upload/23206u45664_ne-prosto-orchestra-saundtreki-naruto-avatar.jpeg",
                        "«Ne prosto orchestra» представляет: Саундтреки «Наруто» и «Аватар»", 8500
                    },
                    {
                        new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), "David Garrett",
                        new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                        new DateTime(2021, 8, 6, 18, 6, 39, 573, DateTimeKind.Local).AddTicks(1994),
                        "Паганини среди поп-звезд и Джими Хендрикс среди скрипачей, немецкий скрипач-виртуоз David Garrett - международная суперзвезда, которая стирает границы между Моцартом и группой Metallica.",
                        "https://ticketon.kz/files/media/david-garrett-band-stills.jpg",
                        "David Garrett & band UNLIMITED LIVE 2020", 8500
                    },
                    {
                        new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), "Симон Вирсаладзе",
                        new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                        new DateTime(2021, 8, 6, 18, 6, 39, 573, DateTimeKind.Local).AddTicks(2060),
                        "«Легенда о любви» - сказка, корни которой уходят в глубину веков. Она родилась на выжженной солнцем земле Востока и не раз становилась объектом литературных обработок. Зрители впервые увидели спектакль «Легенда о любви» 58 лет назад в Мариинском театре.",
                        "https://ticketon.kz/files/media/legenda-o-lyubvi-v-astana-ballet31023.jpg",
                        "«Легенда о любви» в театре Astana Ballet", 2500
                    },
                    {
                        new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), "Хамит Шангалиев и Алибек Альпиев",
                        new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                        new DateTime(2022, 2, 6, 18, 6, 39, 573, DateTimeKind.Local).AddTicks(2087),
                        "Балет «Султан Бейбарс» - необычайно красивый, поразительно захватывающий рассказ о головокружительном пути к вершинам славы и власти. Такой путь всегда требует жертв во имя служения высшим целям.",
                        "https://ticketon.kz/files/media/sultan-beybarys-astanaballet2021.jpg",
                        "«Султан Бейбарс» в театре Astana Ballet", 4000
                    },
                    {
                        new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), "Дина Рубина",
                        new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                        new DateTime(2021, 12, 6, 18, 6, 39, 573, DateTimeKind.Local).AddTicks(2110),
                        "Мало кто из современных авторов способен читать свои произведения с таким подлинно артистическим мастерством. Два часа пролетают незаметно: Дина Рубина легко держит внимание зала, ее непринужденная интонация, юмор, драматический накал чтения захватывает зрителей и не отпускает до последней минуты встречи.",
                        "https://ticketon.kz/files/media/img-ticketon-101920567164928.jpeg", "Дина Рубина в Алматы",
                        1350
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_Events_CategoryId",
                "Events",
                "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Events");

            migrationBuilder.DropTable(
                "Categories");
        }
    }
}