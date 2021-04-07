using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Basket.Infrastructure.Persistence.Migrations
{
    public partial class CouponIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                "CouponId",
                "Baskets",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                "CouponId",
                "Baskets",
                "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}