using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class BasketChangeEventAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "BasketChangeEvents",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    InsertedAt = table.Column<DateTimeOffset>(nullable: false),
                    BasketChangeType = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_BasketChangeEvents", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BasketChangeEvents");
        }
    }
}