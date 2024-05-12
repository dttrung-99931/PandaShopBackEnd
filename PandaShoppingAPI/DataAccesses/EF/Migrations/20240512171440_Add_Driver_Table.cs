using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_Driver_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "driverId",
                table: "User_",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lat = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false),
                    long_ = table.Column<decimal>(type: "decimal(12,9)", precision: 12, scale: 9, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User__driverId",
                table: "User_",
                column: "driverId",
                unique: true,
                filter: "[driverId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Driver",
                table: "User_",
                column: "driverId",
                principalTable: "Driver",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Driver",
                table: "User_");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_User__driverId",
                table: "User_");

            migrationBuilder.DropColumn(
                name: "driverId",
                table: "User_");
        }
    }
}
