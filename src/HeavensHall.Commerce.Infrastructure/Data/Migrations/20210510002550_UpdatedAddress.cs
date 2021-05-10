using Microsoft.EntityFrameworkCore.Migrations;

namespace HeavensHall.Commerce.Infrastructure.Data.Migrations
{
    public partial class UpdatedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_shipping_shipping_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shipping",
                table: "shipping");

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "addresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_shipping",
                table: "shipping",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_shipping_shipping_id",
                table: "orders",
                column: "shipping_id",
                principalTable: "shipping",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_shipping_shipping_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shipping",
                table: "shipping");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shipping",
                table: "shipping",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_shipping_shipping_id",
                table: "orders",
                column: "shipping_id",
                principalTable: "shipping",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
