using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Order_Delivery_Rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery",
                column: "orderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery",
                column: "orderId",
                unique: true);
        }
    }
}
