using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelsToAccountForRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumns: new[] { "ClientID", "GymID" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumns: new[] { "ClientID", "GymID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumns: new[] { "ClientID", "GymID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Clients");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[,]
                {
                    { 2, 1, true, "Ammar Albesani", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, 2, true, "Ahmad Harhoosh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, false, "Ala' Abusalem", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "WorkingDays", "WorkingHours" },
                values: new object[,]
                {
                    { 1, 1, true, "Dietitian", "Nadine Almasri", "370 JD", "Saturday - Friday", "9:00AM - 5:00PM" },
                    { 2, 2, true, "Trainer", "Al-Hareth Alhyari", "400 JD", "Saturday - Thursday", "9:00AM - 5:00PM" },
                    { 3, 3, true, "Trainer", "Bashar Owainat", "430 JD", "Monday - Friday", "4:00PM - 12:00AM" }
                });
        }
    }
}
