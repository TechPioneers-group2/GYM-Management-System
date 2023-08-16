using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class correctlength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                column: "Length",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                column: "Length",
                value: 3);
        }
    }
}
