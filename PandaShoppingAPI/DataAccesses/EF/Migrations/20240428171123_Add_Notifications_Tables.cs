using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Add_Notifications_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationReceiver",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    fcmToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signalRToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    senderType = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationReceiver", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotificationReceiver_User",
                        column: x => x.userId,
                        principalTable: "User_",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationData",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notificationId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationData", x => x.id);
                    table.ForeignKey(
                        name: "FK_NotificationData_Notification",
                        column: x => x.notificationId,
                        principalTable: "Notification",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_NotificationData_Order",
                        column: x => x.orderId,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notificationId = table.Column<int>(type: "int", nullable: false),
                    notificationReceiverId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    seenDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserNotification_Notification",
                        column: x => x.notificationId,
                        principalTable: "Notification",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserNotification_NotificationReceiver",
                        column: x => x.notificationId,
                        principalTable: "NotificationReceiver",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationData_notificationId",
                table: "NotificationData",
                column: "notificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationData_orderId",
                table: "NotificationData",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationReceiver_userId",
                table: "NotificationReceiver",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_notificationId",
                table: "UserNotification",
                column: "notificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationData");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationReceiver");
        }
    }
}
