using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class seeddata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "021f08c5-7a73-487e-8cf2-aa9bc7380629");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03ada377-c8b1-4f00-af42-5ce2a160f78f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e7dbc95-e860-42c6-81f2-f0cb42d97352");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "83f60b0a-34f2-4379-8728-8771a5853804");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "83f60b0a-34f2-4379-8728-8771a5853804");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "83f60b0a-34f2-4379-8728-8771a5853804");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "74d5be6d-f19f-4be3-bdc1-a591123648ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "74d5be6d-f19f-4be3-bdc1-a591123648ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "74d5be6d-f19f-4be3-bdc1-a591123648ad", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" },
                    { "83f60b0a-34f2-4379-8728-8771a5853804", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "acbd167b-fb08-49d6-a2e5-b892422699dd", "AQAAAAIAAYagAAAAEHo0r+Y/rxZxh6e3tru6vNPc3LGe/bWpB2c2GKtoGbQbLTP+c+s80V/gmyLDOESclA==", "66d4b29e-0d96-4e95-a96a-c644df502a22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46d64411-e579-4e42-9a34-3453b4f1df1e", "AQAAAAIAAYagAAAAEKTfh9M0NtbuqyvmItfW0MXrpusIwRsGnIfogh6akDM3blcx3GriK1HiVVrVTeskiA==", "a19eca7f-0d18-48f0-a7b3-16f44ec99ce6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b55c92da-32c0-43c4-bf58-32c46be64e8d", "AQAAAAIAAYagAAAAEI4pEyMY6pSXbpNBHA3iRcjHsyesGrudL6uUOINFw+8RNR1vsh9hjT3P6M0ltF5zwA==", "b01e9541-15a8-41bb-9aab-821065fbe8b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c8298d3-2bb8-4942-b227-9e467a4d1520", "AQAAAAIAAYagAAAAEBRWtsu30PgIRu4nsMcOqKXX8Ay2CGAYTomXj7xmM7ydQigHjbUQPSRYPi+HzBIZPw==", "41c1985d-5ff2-4592-a9bb-badd0f03d174" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4735), new DateTime(2024, 4, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4755) });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID", "UserId" },
                values: new object[] { 2, 1, true, "Client2", new DateTime(2023, 10, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4767), new DateTime(2024, 4, 14, 15, 20, 51, 703, DateTimeKind.Local).AddTicks(4768), 1, "4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16a4e36a-0efa-41e5-9a7a-8fbd6e4cdefb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74d5be6d-f19f-4be3-bdc1-a591123648ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f60b0a-34f2-4379-8728-8771a5853804");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "7e7dbc95-e860-42c6-81f2-f0cb42d97352");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "7e7dbc95-e860-42c6-81f2-f0cb42d97352");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "7e7dbc95-e860-42c6-81f2-f0cb42d97352");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "7e7dbc95-e860-42c6-81f2-f0cb42d97352");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "03ada377-c8b1-4f00-af42-5ce2a160f78f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "03ada377-c8b1-4f00-af42-5ce2a160f78f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "03ada377-c8b1-4f00-af42-5ce2a160f78f");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "021f08c5-7a73-487e-8cf2-aa9bc7380629");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "021f08c5-7a73-487e-8cf2-aa9bc7380629");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "021f08c5-7a73-487e-8cf2-aa9bc7380629", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" },
                    { "03ada377-c8b1-4f00-af42-5ce2a160f78f", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "7e7dbc95-e860-42c6-81f2-f0cb42d97352", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1887ee94-cfb2-4467-87e4-4ab27fb0efed", "AQAAAAIAAYagAAAAEGR/NTOFqUQRCgSf8BE0aT8SyVFMMVmLFnhJcwRY5PxcbSdHLHf2XtbT2g7k+L7jCQ==", "ef0bb341-fc6b-454e-9094-ec7840a36e06" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8fcc4ee-7d6d-4a90-87e4-dce69c81130c", "AQAAAAIAAYagAAAAEJXaC6AjsFkv2v6msTkDnjCRQLQpPBl/HSXNYD4t8F+k2OYT7Y3PHN3j7fUln00w9g==", "92fbd94c-0102-4a74-a98e-bfec0ba8e5bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2412089-4a4c-4cb4-83b9-c175652186dd", "AQAAAAIAAYagAAAAEI5HKXshEHpN4vxCBVXCAgSDf8p5zvIH9iOE3talsTv8ZV6ukU1ahwpRDEky1Byxpg==", "071d0df4-396d-4948-977d-76e9110047cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a4a10fb-d3e3-45f9-825b-49d1bc054d0d", "AQAAAAIAAYagAAAAEL/EYZJPxmt517Bzx2e6dI8P7U0Hmm3gNJFn1qWg+/8U0zqYg7SWqNqP3lDd8pfv+g==", "23814a43-5e60-4231-8d89-71b670611053" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 14, 14, 29, 26, 159, DateTimeKind.Local).AddTicks(9004), new DateTime(2024, 4, 14, 14, 29, 26, 159, DateTimeKind.Local).AddTicks(9025) });
        }
    }
}
