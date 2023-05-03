using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Bookings",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Bookings",
                newName: "EndDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Bookings",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Bookings",
                newName: "End");
        }
    }
}
