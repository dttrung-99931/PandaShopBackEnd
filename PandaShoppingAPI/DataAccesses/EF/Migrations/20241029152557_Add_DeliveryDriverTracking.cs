using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_DeliveryDriverTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryDriverTracking",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryDriverId = table.Column<int>(type: "int", nullable: false),
                    lat = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false),
                    long_ = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false),
                    bearingInDegree = table.Column<double>(type: "float", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDriverTracking", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeliveryDriverTracking_DeliveryDriver",
                        column: x => x.deliveryDriverId,
                        principalTable: "DeliveryDriver",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDriverTracking_deliveryDriverId",
                table: "DeliveryDriverTracking",
                column: "deliveryDriverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryDriverTracking");
        }
    }
}
