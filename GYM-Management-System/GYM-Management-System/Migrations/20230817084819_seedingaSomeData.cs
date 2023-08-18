using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class seedingaSomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "WorkingDays", "WorkingHours" },
                values: new object[,]
                {
                    { 1, 1, false, "coach", "Ahmad", "500", "sun-thu", "2-10" },
                    { 2, 1, false, "trainer", "moh", "500", "sun-thu", "2-10" }
                });

            migrationBuilder.InsertData(
                table: "GymEquipments",
                columns: new[] { "GymEquipmentID", "GymID", "Name", "OutOfService", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "tradmal", 0, 5 },
                    { 2, 1, "bench press", 0, 2 }
                });

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 1,
                columns: new[] { "Length", "Name" },
                values: new object[] { 1, "one month" });

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                columns: new[] { "Length", "Name", "Price" },
                values: new object[] { 3, "3 months", "50 JD" });

            migrationBuilder.InsertData(
                table: "SubscriptionTiers",
                columns: new[] { "SubscriptionTierID", "Length", "Name", "Price" },
                values: new object[] { 3, 6, "6 months", "80 JD" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 1,
                columns: new[] { "Length", "Name" },
                values: new object[] { 3, "3 months" });

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                columns: new[] { "Length", "Name", "Price" },
                values: new object[] { 6, "6 months", "150 JD" });
        }
    }
}
