using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Update_Order_RemovepaymentMethodId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentMethod_paymentMethodId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_PaymentMethod_PaymentMethodid",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_PaymentMethodid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PaymentMethodid",
                table: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PaymentMethod",
                table: "Invoice",
                column: "paymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentMethod",
                table: "Invoice");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodid",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentMethodid",
                table: "Order",
                column: "PaymentMethodid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PaymentMethod_paymentMethodId",
                table: "Invoice",
                column: "paymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_PaymentMethod_PaymentMethodid",
                table: "Order",
                column: "PaymentMethodid",
                principalTable: "PaymentMethod",
                principalColumn: "id");
        }
    }
}
