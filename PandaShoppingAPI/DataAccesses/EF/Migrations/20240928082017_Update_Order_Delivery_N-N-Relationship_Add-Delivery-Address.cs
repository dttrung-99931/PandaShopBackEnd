using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Order_Delivery_NNRelationship_AddDeliveryAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Order",
                table: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery");

            migrationBuilder.AddColumn<int>(
                name: "deliveryAddressId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 20);

            migrationBuilder.CreateTable(
                name: "OrderDelivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDelivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDelivery_Delivery",
                        column: x => x.deliveryId,
                        principalTable: "Delivery",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderDelivery_Order",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryAddressId",
                table: "Order",
                column: "deliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDelivery_deliveryId",
                table: "OrderDelivery",
                column: "deliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDelivery_orderId",
                table: "OrderDelivery",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Address",
                table: "Order",
                column: "deliveryAddressId",
                principalTable: "Address",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Address",
                table: "Order");

            migrationBuilder.DropTable(
                name: "OrderDelivery");

            migrationBuilder.DropIndex(
                name: "IX_Order_deliveryAddressId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "deliveryAddressId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_orderId",
                table: "Delivery",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Order",
                table: "Delivery",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "id");
        }
    }
}
