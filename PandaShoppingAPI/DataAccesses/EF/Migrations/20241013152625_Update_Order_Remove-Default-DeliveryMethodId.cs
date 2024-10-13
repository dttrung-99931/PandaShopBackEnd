using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Order_RemoveDefaultDeliveryMethodId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "deliveryMethodId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "deliveryMethodId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 3,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
