using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Baskets",
                table => new
                {
                    BasketId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Baskets", x => x.BasketId); });

            migrationBuilder.CreateTable(
                "BasketLines",
                table => new
                {
                    BasketLineId = table.Column<Guid>(nullable: false),
                    BasketId = table.Column<Guid>(nullable: false),
                    EventId = table.Column<Guid>(nullable: false),
                    TicketAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLines", x => x.BasketLineId);
                    table.ForeignKey(
                        "FK_BasketLines_Baskets_BasketId",
                        x => x.BasketId,
                        "Baskets",
                        "BasketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_BasketLines_BasketId",
                "BasketLines",
                "BasketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "BasketLines");

            migrationBuilder.DropTable(
                "Baskets");
        }
    }
}