using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Order_AdddeliveryMethodId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deliveryMethodId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryMethodId",
                table: "Order",
                column: "deliveryMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryMethod",
                table: "Order",
                column: "deliveryMethodId",
                principalTable: "DeliveryMethod",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryMethod",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_deliveryMethodId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "deliveryMethodId",
                table: "Order");
        }
    }
}
