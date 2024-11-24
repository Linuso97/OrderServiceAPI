using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_CustomerId",
                table: "OrderRequests",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequestItems_ProductId",
                table: "OrderRequestItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRequestItems_Products_ProductId",
                table: "OrderRequestItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRequests_Customers_CustomerId",
                table: "OrderRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
