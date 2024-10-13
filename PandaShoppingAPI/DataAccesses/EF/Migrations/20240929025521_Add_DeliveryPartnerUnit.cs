using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_DeliveryPartnerUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deliveryPartnerUnitId",
                table: "ProductDeliveryMethod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DeliveryPartnerUnit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    deliveryPartnerId = table.Column<int>(type: "int", nullable: false),
                    addressId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPartnerUnit", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeliveryPartnerUnit_Address_addressId",
                        column: x => x.addressId,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPartnerUnit_DeliveryPartner",
                        column: x => x.deliveryPartnerId,
                        principalTable: "DeliveryPartner",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeliveryMethod_deliveryPartnerUnitId",
                table: "ProductDeliveryMethod",
                column: "deliveryPartnerUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPartnerUnit_addressId",
                table: "DeliveryPartnerUnit",
                column: "addressId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPartnerUnit_deliveryPartnerId",
                table: "DeliveryPartnerUnit",
                column: "deliveryPartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit",
                table: "ProductDeliveryMethod",
                column: "deliveryPartnerUnitId",
                principalTable: "DeliveryPartnerUnit",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit",
                table: "ProductDeliveryMethod");

            migrationBuilder.DropTable(
                name: "DeliveryPartnerUnit");

            migrationBuilder.DropIndex(
                name: "IX_ProductDeliveryMethod_deliveryPartnerUnitId",
                table: "ProductDeliveryMethod");

            migrationBuilder.DropColumn(
                name: "deliveryPartnerUnitId",
                table: "ProductDeliveryMethod");
        }
    }
}
