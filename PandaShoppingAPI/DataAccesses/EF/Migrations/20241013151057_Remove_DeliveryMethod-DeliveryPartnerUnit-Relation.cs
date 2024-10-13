using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Remove_DeliveryMethodDeliveryPartnerUnitRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit",
                table: "ProductDeliveryMethod");

            migrationBuilder.RenameColumn(
                name: "deliveryPartnerUnitId",
                table: "ProductDeliveryMethod",
                newName: "DeliveryPartnerUnitid");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDeliveryMethod_deliveryPartnerUnitId",
                table: "ProductDeliveryMethod",
                newName: "IX_ProductDeliveryMethod_DeliveryPartnerUnitid");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryPartnerUnitid",
                table: "ProductDeliveryMethod",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit_DeliveryPartnerUnitid",
                table: "ProductDeliveryMethod",
                column: "DeliveryPartnerUnitid",
                principalTable: "DeliveryPartnerUnit",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit_DeliveryPartnerUnitid",
                table: "ProductDeliveryMethod");

            migrationBuilder.RenameColumn(
                name: "DeliveryPartnerUnitid",
                table: "ProductDeliveryMethod",
                newName: "deliveryPartnerUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDeliveryMethod_DeliveryPartnerUnitid",
                table: "ProductDeliveryMethod",
                newName: "IX_ProductDeliveryMethod_deliveryPartnerUnitId");

            migrationBuilder.AlterColumn<int>(
                name: "deliveryPartnerUnitId",
                table: "ProductDeliveryMethod",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDeliveryMethod_DeliveryPartnerUnit",
                table: "ProductDeliveryMethod",
                column: "deliveryPartnerUnitId",
                principalTable: "DeliveryPartnerUnit",
                principalColumn: "id");
        }
    }
}
