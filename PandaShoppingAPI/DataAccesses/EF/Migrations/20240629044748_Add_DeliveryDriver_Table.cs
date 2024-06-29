using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_DeliveryDriver_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryDriver",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryId = table.Column<int>(type: "int", nullable: false),
                    driverId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDriver", x => x.id);
                    table.ForeignKey(
                        name: "FK_DeliveryDriver_Delivery",
                        column: x => x.deliveryId,
                        principalTable: "Delivery",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DeliveryDriver_Driver",
                        column: x => x.driverId,
                        principalTable: "Driver",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDriver_deliveryId",
                table: "DeliveryDriver",
                column: "deliveryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDriver_driverId",
                table: "DeliveryDriver",
                column: "driverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryDriver");
        }
    }
}
