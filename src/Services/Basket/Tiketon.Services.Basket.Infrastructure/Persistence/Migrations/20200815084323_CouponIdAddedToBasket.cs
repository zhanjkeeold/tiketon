using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class CouponIdAddedToBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                "CouponId",
                "Baskets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "CouponId",
                "Baskets");
        }
    }
}