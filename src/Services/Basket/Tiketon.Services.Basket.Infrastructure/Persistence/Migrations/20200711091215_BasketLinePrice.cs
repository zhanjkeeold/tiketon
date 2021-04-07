using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class BasketLinePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "Price",
                "BasketLines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Price",
                "BasketLines");
        }
    }
}