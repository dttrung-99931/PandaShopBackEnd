using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Fix_FK_UserNotificaiton_NotificatinReceiver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_NotificationReceiver",
                table: "UserNotification");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_notificationReceiverId",
                table: "UserNotification",
                column: "notificationReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_NotificationReceiver",
                table: "UserNotification",
                column: "notificationReceiverId",
                principalTable: "NotificationReceiver",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_NotificationReceiver",
                table: "UserNotification");

            migrationBuilder.DropIndex(
                name: "IX_UserNotification_notificationReceiverId",
                table: "UserNotification");

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_NotificationReceiver",
                table: "UserNotification",
                column: "notificationId",
                principalTable: "NotificationReceiver",
                principalColumn: "id");
        }
    }
}
