using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatenameOfOrederesStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersStatuses",
                table: "OrdersStatuses");

            migrationBuilder.RenameTable(
                name: "OrdersStatuses",
                newName: "OrdersStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersStatus",
                table: "OrdersStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrdersStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersStatus",
                table: "OrdersStatus");

            migrationBuilder.RenameTable(
                name: "OrdersStatus",
                newName: "OrdersStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersStatuses",
                table: "OrdersStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrdersStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
