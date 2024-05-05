using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_NotificationReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fcmToken",
                table: "NotificationReceiver");

            migrationBuilder.RenameColumn(
                name: "signalRToken",
                table: "NotificationReceiver",
                newName: "token");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "token",
                table: "NotificationReceiver",
                newName: "signalRToken");

            migrationBuilder.AddColumn<string>(
                name: "fcmToken",
                table: "NotificationReceiver",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
