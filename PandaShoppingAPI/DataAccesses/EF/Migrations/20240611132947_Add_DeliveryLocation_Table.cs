using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_DeliveryLocation_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Address",
                table: "Delivery");

            migrationBuilder.RenameColumn(
                name: "addressId",
                table: "Delivery",
                newName: "Addressid");

            migrationBuilder.RenameIndex(
                name: "IX_Delivery_addressId",
                table: "Delivery",
                newName: "IX_Delivery_Addressid");

            migrationBuilder.AlterColumn<int>(
                name: "Addressid",
                table: "Delivery",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DeliveryLocation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    locationType = table.Column<int>(type: "int", nullable: false),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryLocation", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeliveryLocation_Address",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DeliveryLocation_Delivery",
                        column: x => x.deliveryId,
                        principalTable: "Delivery",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocation_addressId",
                table: "DeliveryLocation",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryLocation_deliveryId",
                table: "DeliveryLocation",
                column: "deliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Address_Addressid",
                table: "Delivery",
                column: "Addressid",
                principalTable: "Address",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_Address_Addressid",
                table: "Delivery");

            migrationBuilder.DropTable(
                name: "DeliveryLocation");

            migrationBuilder.RenameColumn(
                name: "Addressid",
                table: "Delivery",
                newName: "addressId");

            migrationBuilder.RenameIndex(
                name: "IX_Delivery_Addressid",
                table: "Delivery",
                newName: "IX_Delivery_addressId");

            migrationBuilder.AlterColumn<int>(
                name: "addressId",
                table: "Delivery",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_Address",
                table: "Delivery",
                column: "addressId",
                principalTable: "Address",
                principalColumn: "id");
        }
    }
}
