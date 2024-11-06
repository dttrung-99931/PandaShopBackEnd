using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_OrderremovedefaultshopId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "shopId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "shopId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
