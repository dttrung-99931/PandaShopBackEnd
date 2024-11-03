using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_DeliveryDriverdriverLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "distanceInMetter",
                table: "DeliveryDriver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "driverBearingInDegree",
                table: "DeliveryDriver",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "driverLat",
                table: "DeliveryDriver",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "driverLong",
                table: "DeliveryDriver",
                type: "decimal(12,9)",
                precision: 12,
                scale: 9,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "durationInMinute",
                table: "DeliveryDriver",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "remainingDistance",
                table: "DeliveryDriver",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "distanceInMetter",
                table: "DeliveryDriver");

            migrationBuilder.DropColumn(
                name: "driverBearingInDegree",
                table: "DeliveryDriver");

            migrationBuilder.DropColumn(
                name: "driverLat",
                table: "DeliveryDriver");

            migrationBuilder.DropColumn(
                name: "driverLong",
                table: "DeliveryDriver");

            migrationBuilder.DropColumn(
                name: "durationInMinute",
                table: "DeliveryDriver");

            migrationBuilder.DropColumn(
                name: "remainingDistance",
                table: "DeliveryDriver");
        }
    }
}
