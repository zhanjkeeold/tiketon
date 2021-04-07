using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiketon.Services.Discount.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Coupons",
                table => new
                {
                    CouponId = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    AlreadyUsed = table.Column<bool>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Coupons", x => x.CouponId); });

            migrationBuilder.InsertData(
                "Coupons",
                new[] {"CouponId", "AlreadyUsed", "Amount", "Code"},
                new object[] {new Guid("3416eeca-e569-44fe-a06e-b0eb0d70a855"), false, 10, "Ten"});

            migrationBuilder.InsertData(
                "Coupons",
                new[] {"CouponId", "AlreadyUsed", "Amount", "Code"},
                new object[] {new Guid("819200b3-f05b-4416-a846-534228c26195"), false, 20, "Twenty"});

            migrationBuilder.InsertData(
                "Coupons",
                new[] {"CouponId", "AlreadyUsed", "Amount", "Code"},
                new object[] {new Guid("aed65b30-071f-4058-b42b-6ac0955ca3b9"), false, 100, "AlmostFree"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Coupons");
        }
    }
}