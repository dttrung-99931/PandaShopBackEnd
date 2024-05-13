using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Address_Addlonglat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "lat",
                table: "Address",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "long_",
                table: "Address",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lat",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "long_",
                table: "Address");
        }
    }
}
