using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class Events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Events",
                table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Events", x => x.EventId); });

            migrationBuilder.CreateIndex(
                "IX_BasketLines_EventId",
                "BasketLines",
                "EventId");

            migrationBuilder.AddForeignKey(
                "FK_BasketLines_Events_EventId",
                "BasketLines",
                "EventId",
                "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_BasketLines_Events_EventId",
                "BasketLines");

            migrationBuilder.DropTable(
                "Events");

            migrationBuilder.DropIndex(
                "IX_BasketLines_EventId",
                "BasketLines");
        }
    }
}