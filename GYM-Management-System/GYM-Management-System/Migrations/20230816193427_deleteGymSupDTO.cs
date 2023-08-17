using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class deleteGymSupDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "GymSupplements");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Supplements");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "GymSupplements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
