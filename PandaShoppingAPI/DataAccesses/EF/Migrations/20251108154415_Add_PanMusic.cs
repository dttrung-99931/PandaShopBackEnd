using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_PanMusic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "panMusicId",
                table: "PanVideo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PanMusic",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    durationInSecs = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanMusic", x => x.id);
                    table.ForeignKey(
                        name: "FK_PanMusic_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PanVideo_panMusicId",
                table: "PanVideo",
                column: "panMusicId");

            migrationBuilder.CreateIndex(
                name: "IX_PanMusic_userId",
                table: "PanMusic",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_PanVideo_PanMusic",
                table: "PanVideo",
                column: "panMusicId",
                principalTable: "PanMusic",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanVideo_PanMusic",
                table: "PanVideo");

            migrationBuilder.DropTable(
                name: "PanMusic");

            migrationBuilder.DropIndex(
                name: "IX_PanVideo_panMusicId",
                table: "PanVideo");

            migrationBuilder.DropColumn(
                name: "panMusicId",
                table: "PanVideo");
        }
    }
}
