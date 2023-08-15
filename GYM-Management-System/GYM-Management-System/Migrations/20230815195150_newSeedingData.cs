using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class newSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymID", "ActiveHours", "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[,]
                {
                    { 1, "5AM-9PM", "Amman", 0, "150", "GYM1", "Every thing ok" },
                    { 2, "5AM-9PM", "Zarqa", 0, "150", "GYM1", "Every thing ok" }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionTiers",
                columns: new[] { "SubscriptionTierID", "Length", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3 months", "30 JD" },
                    { 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 months", "150 JD" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[] { 1, 1, false, "ammar", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 1);
        }
    }
}
