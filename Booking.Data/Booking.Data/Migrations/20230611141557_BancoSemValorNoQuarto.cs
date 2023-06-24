using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Data.Migrations
{
    /// <inheritdoc />
    public partial class BancoSemValorNoQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
