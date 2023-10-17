using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class azure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "335683c4-15f5-44fc-a090-8c397857f616");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cf079d3-f3d9-489b-ae49-b853ea003a49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e77ad224-d7fe-4562-8ca7-f2255537ba57");

            migrationBuilder.RenameColumn(
                name: "img",
                table: "GymEquipments",
                newName: "PhotoUrl");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "2d865ed7-99c4-4747-be7b-ef0b44a00459");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "2d865ed7-99c4-4747-be7b-ef0b44a00459");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "2d865ed7-99c4-4747-be7b-ef0b44a00459");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "2d865ed7-99c4-4747-be7b-ef0b44a00459");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "c1872983-0667-47ac-ac7e-f3754c7e8a01");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "c1872983-0667-47ac-ac7e-f3754c7e8a01");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "c1872983-0667-47ac-ac7e-f3754c7e8a01");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "e1ddbe4f-ca50-4928-be1b-176a046a12b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "e1ddbe4f-ca50-4928-be1b-176a046a12b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d865ed7-99c4-4747-be7b-ef0b44a00459", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "c1872983-0667-47ac-ac7e-f3754c7e8a01", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "e1ddbe4f-ca50-4928-be1b-176a046a12b6", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8516e032-c0f2-4685-bcbb-ba3d72533fef", "AQAAAAIAAYagAAAAEJmzu7+JsS/tQjO3a7jDlOjzup0eeiVu5Bx1Oaq9St3NTmMiSSB+1Urqe9L9fcaC/g==", "82d1480a-e6d4-437c-ae51-ec2d971f9581" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcb10b71-f250-48e5-accc-cc265ef2277a", "AQAAAAIAAYagAAAAEHsUK2bQaW3aDbylLRQuAleQcwRXr/viZ3MYsHLxCWV0V13eNhvoiQYm9Igb8ClZhw==", "239ab76e-4580-4dc8-bb1e-cd25250aedc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "873859e5-6e71-4871-bbd5-e12f7db4fd9e", "AQAAAAIAAYagAAAAEKWJ9AAaO14RCycBg+VB/07/Y122K2jVKkzMBOBygzhxkPu0R/LW2+qLmG9TmNL6Jg==", "17536a36-6f69-4c78-8d6e-dbe6fe1eeb0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a02f881-c8f0-425c-ae8c-6a5b19e479d3", "AQAAAAIAAYagAAAAEBGqw9sngCwb+u95rik51AWFFLIWB9TZh5XYeqGbwboi9JM/xDj8iJgDCrBrzfjVqA==", "45c83d57-35f6-4b0e-9069-03d14c6a65aa" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3718), new DateTime(2024, 4, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3738) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3747), new DateTime(2024, 4, 16, 16, 1, 4, 455, DateTimeKind.Local).AddTicks(3748) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d865ed7-99c4-4747-be7b-ef0b44a00459");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1872983-0667-47ac-ac7e-f3754c7e8a01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ddbe4f-ca50-4928-be1b-176a046a12b6");

            migrationBuilder.RenameColumn(
                name: "PhotoUrl",
                table: "GymEquipments",
                newName: "img");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "e77ad224-d7fe-4562-8ca7-f2255537ba57");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "e77ad224-d7fe-4562-8ca7-f2255537ba57");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "e77ad224-d7fe-4562-8ca7-f2255537ba57");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "e77ad224-d7fe-4562-8ca7-f2255537ba57");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "335683c4-15f5-44fc-a090-8c397857f616");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "335683c4-15f5-44fc-a090-8c397857f616");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "335683c4-15f5-44fc-a090-8c397857f616");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "7cf079d3-f3d9-489b-ae49-b853ea003a49");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "7cf079d3-f3d9-489b-ae49-b853ea003a49");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "335683c4-15f5-44fc-a090-8c397857f616", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "7cf079d3-f3d9-489b-ae49-b853ea003a49", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" },
                    { "e77ad224-d7fe-4562-8ca7-f2255537ba57", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "459f11a8-2725-42fc-aec3-094fe06d2081", "AQAAAAIAAYagAAAAEEVoQQMAYvmEENFbC3Q5MLvpRq73wiHIqdo1wy2OQ2EVopUsH+PFs1NH5tcA/pEF1A==", "5f3deec2-3463-4733-a6b5-6cdf6bad1407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9128827-9b9d-47f7-84d5-885d9407f966", "AQAAAAIAAYagAAAAEBNjhmcIUCmp+zdKLimR9LRbj1MudWFay1GxG3XUbLAqrEnbtH2k7IxXlhs7whEXUA==", "802a8417-e830-4c66-8b53-5d7bdc0d7c4a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03e9639-4381-43d5-a56a-af98c9b6743b", "AQAAAAIAAYagAAAAEMEmEavHnAZb9AFWy6PhfgStKa2sdH0zA25oi2JZLbpyYuUkK/5otguStz0Vr5kHzw==", "e13116f2-fb6f-4d5e-9f6f-d0588f388cca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "034b3b94-a1de-4809-b0a4-d484455cbe0e", "AQAAAAIAAYagAAAAEG0D7vIN974Mg1Il33+pmpn+TNOn/5pSXLEagi6HmFQ+Urmpi1pnmazsum6UDxnLDw==", "3cce63da-3ce3-487d-a279-ff33ceda1645" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 16, 10, 20, 46, 104, DateTimeKind.Local).AddTicks(1174), new DateTime(2024, 4, 16, 10, 20, 46, 104, DateTimeKind.Local).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 16, 10, 20, 46, 104, DateTimeKind.Local).AddTicks(1206), new DateTime(2024, 4, 16, 10, 20, 46, 104, DateTimeKind.Local).AddTicks(1207) });
        }
    }
}
