using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusIdForOrderStatusTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "OrdersStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "OrdersStatuses");
        }
    }
}
