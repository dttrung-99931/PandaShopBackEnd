using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaShoppingAPI.DataAccesses.EF.Migrations
{
    public partial class Fix_InvoiceOrder_Rel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Invoice",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_orderId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Order_invoiceId",
                table: "Order",
                column: "invoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Invoice",
                table: "Order",
                column: "invoiceId",
                principalTable: "Invoice",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Invoice",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_invoiceId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_orderId",
                table: "Invoice",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Invoice",
                table: "Order",
                column: "userId",
                principalTable: "Invoice",
                principalColumn: "id");
        }
    }
}
