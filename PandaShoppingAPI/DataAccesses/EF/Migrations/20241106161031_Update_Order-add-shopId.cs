using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_OrderaddshopId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "shopId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Order_shopId",
                table: "Order",
                column: "shopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Shop",
                table: "Order",
                column: "shopId",
                principalTable: "Shop",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Shop",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_shopId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "shopId",
                table: "Order");
        }
    }
}
