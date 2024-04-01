using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.Migrations.Database
{
    /// <inheritdoc />
    public partial class changeItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StorageLocation",
                table: "Items",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageLocation",
                table: "Items");
        }
    }
}
