using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogiTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderInventoryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Orders_InventoryItem",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "InventoryItem",
                table: "InventoryItems",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_InventoryItem",
                table: "InventoryItems",
                newName: "IX_InventoryItems_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Orders_OrderId",
                table: "InventoryItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_Orders_OrderId",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "InventoryItems",
                newName: "InventoryItem");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryItems_OrderId",
                table: "InventoryItems",
                newName: "IX_InventoryItems_InventoryItem");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_Orders_InventoryItem",
                table: "InventoryItems",
                column: "InventoryItem",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
