using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class dataSeedingForAdminEmployeeClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "5a0b4455-2f58-4777-a919-b7c710332938", "adminUser@example.com", true, false, null, "ADMINUSER@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAECTyAS/oMp0mH7AeThUuP0iNUBd5a+KhYMOF1YwVsxINlCbZI3Ct20uhzDEeqrUsPQ==", "1234567890", false, "1f2a9f5d-0247-4fc2-96b8-a054328b8877", false, "Admin" },
                    { "2", 0, "63cf1300-13ce-40d3-a8ea-0a0105b3589f", "employeeUser@example.com", true, false, null, "EMPLOYEEUSER@EXAMPLE.COM", "EMPLOYEE", "AQAAAAIAAYagAAAAEKV+7tj6Pmc0kJTmknpzZT3Azl7/eNQk+gIVhrR4I82SOr3qM7UoDPJMKkQ5vkZLBw==", "1234567890", false, "fd2f7db5-8839-4a1f-b7cf-3b447eefa407", false, "Employee" },
                    { "3", 0, "b75196b6-2a17-4c13-82dd-5b2ca83c381a", "ClientUser@example.com", true, false, null, "CLIENTUSER@EXAMPLE.COM", "CLIENT", "AQAAAAIAAYagAAAAED1LP34E0AtQ+mPv8k7dCkOurKfRk7IHQIiQBb+YeIN4jbzV2nCzQFUdT09oOWoISw==", "1234567890", false, "f9b97d9b-d2df-4da8-9be5-b65f89698e1e", false, "Client" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID", "UserId" },
                values: new object[] { 1, 1, true, "Client", new DateTime(2023, 10, 14, 13, 58, 41, 317, DateTimeKind.Local).AddTicks(1292), new DateTime(2024, 4, 14, 13, 58, 41, 317, DateTimeKind.Local).AddTicks(1304), 1, "3" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "GymID", "IsAvailable", "JobDescription", "Name", "Salary", "UserId", "WorkingDays", "WorkingHours" },
                values: new object[] { 1, 1, true, "Demo", "Employee", "$300", "2", "S M T W T F S", "9AM - 5PM" });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3,
                columns: new[] { "OutOfService", "Quantity" },
                values: new object[] { 2, 10 });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "Quantity",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 3,
                column: "Notification",
                value: "Under maintenance until 9-9-2023 AD");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "Admin", "1" },
                    { "Employee", "2" },
                    { "Client", "3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Admin", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Employee", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Client", "3" });

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3,
                columns: new[] { "OutOfService", "Quantity" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "Quantity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 3,
                column: "Notification",
                value: "Everything ok");
        }
    }
}
