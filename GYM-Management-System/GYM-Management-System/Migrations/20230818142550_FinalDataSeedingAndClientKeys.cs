using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class FinalDataSeedingAndClientKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumns: new[] { "ClientID", "GymID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumns: new[] { "ClientID", "GymID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionExpiry",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[,]
                {
                    { 2, 1, true, "Ammar Albesani", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 1, 2, true, "Ahmad Harhoosh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "JobDescription", "Name", "Salary", "WorkingDays" },
                values: new object[] { "Dietitian", "Nadine Almasri", "370 JD", "Saturday - Friday" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "WorkingDays", "WorkingHours" },
                values: new object[] { 2, 2, true, "Trainer", "Al-Hareth Alhyari", "400 JD", "Saturday - Thursday", "9:00AM - 5:00PM" });

            migrationBuilder.InsertData(
                table: "GymEquipments",
                columns: new[] { "GymEquipmentID", "GymID", "Name", "OutOfService", "Quantity" },
                values: new object[,]
                {
                    { 2, 1, "bench press", 0, 2 },
                    { 3, 1, "treadmill", 1, 5 },
                    { 4, 2, "dumbbells", 0, 10 },
                    { 5, 2, "elliptical machine", 0, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1,
                columns: new[] { "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[] { "Amman - University Street - Building 25", 1, "125", "WillPower - Amman", "Everything ok" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2,
                columns: new[] { "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[] { "Zarqa - 36th Street - Building 20", 1, "100", "WillPower - Zarqa", "Everything ok" });

            migrationBuilder.InsertData(
                table: "Gyms",
                columns: new[] { "GymID", "ActiveHours", "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[] { 3, "6AM-12PM", "Irbid - Yarmouk University Street - Building 30", 0, "150", "WillPower - Irbid", "Everything ok" });

            migrationBuilder.InsertData(
                table: "SubscriptionTiers",
                columns: new[] { "SubscriptionTierID", "Length", "Name", "Price" },
                values: new object[] { 4, 12, "12 months", "200 JD" });

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "SupplementID", "Name", "Price" },
                values: new object[,]
                {
                    { 2, "Creatine Monohydrate", "40 JD" },
                    { 3, "Branched-Chain Amino Acids (BCAAs)", "30 JD" },
                    { 4, "Pre-Workout Blend", "50 JD" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[] { 3, 3, false, "Ala' Abusalem", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "WorkingDays", "WorkingHours" },
                values: new object[] { 3, 3, true, "Trainer", "Bashar Owainat", "430 JD", "Monday - Friday", "4:00PM - 12:00AM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionExpiry",
                table: "Clients",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubscriptionDate",
                table: "Clients",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[,]
                {
                    { 1, 1, false, "Ahmad Harhoosh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, false, "Ammar Albisany", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "JobDescription", "Name", "Salary", "WorkingDays" },
                values: new object[] { "Trainer", "Ahmad Albisany", "330 JD", "Sat - Fri" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1,
                columns: new[] { "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[] { "Amman", 0, "150", "WillPower-Amman", "Every thing ok" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2,
                columns: new[] { "Address", "CurrentCapacity", "MaxCapacity", "Name", "Notification" },
                values: new object[] { "Zarqa", 0, "120", "WillPower-Zarqa", "Every thing ok" });
        }
    }
}
