using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class addedImageToSupplementAndGyms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Supplements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imageURL",
                table: "Gyms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "c8299033-7c40-4f8e-8088-c46ba6e42ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "c8299033-7c40-4f8e-8088-c46ba6e42ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "c8299033-7c40-4f8e-8088-c46ba6e42ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "c8299033-7c40-4f8e-8088-c46ba6e42ddc");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "69bdf35b-af27-421a-aa17-0c3cb3b8fa64");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "69bdf35b-af27-421a-aa17-0c3cb3b8fa64");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "69bdf35b-af27-421a-aa17-0c3cb3b8fa64");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "7bb5804a-c312-493e-b8c0-92cea40dbb94");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "7bb5804a-c312-493e-b8c0-92cea40dbb94");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "69bdf35b-af27-421a-aa17-0c3cb3b8fa64", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "7bb5804a-c312-493e-b8c0-92cea40dbb94", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" },
                    { "c8299033-7c40-4f8e-8088-c46ba6e42ddc", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65b5ec71-64eb-4c2a-9ae7-4734b81ca1a8", "AQAAAAIAAYagAAAAEJSG2hX+CNAJylJqf8bNffOofIF7lLR8sNYadSkJC7oP+qU8RGJpTNmg3Zyuw4cSjw==", "93cc485d-7bfa-4240-b58b-cdda6d9bbc24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a7f1dbf-311d-40a9-b405-56076c52775a", "AQAAAAIAAYagAAAAEGOFH2/Gnh7pw8l/JMFRuzdT04NUOpq+RNEeN9LN1dNsDw/uewsBS0Bj5y0rQ0x4AQ==", "7cd68f51-434d-4ff5-9fde-1a18ac7a4f2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71880366-5124-4966-9c9d-32fa37cff955", "AQAAAAIAAYagAAAAEIjgJVxTJs9l0VTLmJhxHnEQbpZITpzqWtHoOGXcTjRAeqkLTCwt3wczOp1RupcKVQ==", "9a02a880-541e-410c-8dc4-d02b0f6ec2ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "768a5934-71ac-4e9d-abac-dd05c8e14aa8", "AQAAAAIAAYagAAAAEChBnawMX1dlIN9MkVAjcVd09cqoigdxvHL4Rq3IZhBD+8x+Pa6eI3QFdaqxSwhWOw==", "46346f8a-c628-4148-a033-d5f0efc883e9" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 17, 19, 48, 51, 271, DateTimeKind.Local).AddTicks(8198), new DateTime(2024, 4, 17, 19, 48, 51, 271, DateTimeKind.Local).AddTicks(8208) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 17, 19, 48, 51, 271, DateTimeKind.Local).AddTicks(8214), new DateTime(2024, 4, 17, 19, 48, 51, 271, DateTimeKind.Local).AddTicks(8214) });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 3,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 1,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 2,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 3,
                column: "imageURL",
                value: null);

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 4,
                column: "imageURL",
                value: null);

            migrationBuilder.InsertData(
                table: "Supplements",
                columns: new[] { "SupplementID", "Description", "Name", "Price", "imageURL" },
                values: new object[,]
                {
                    { 5, "BCAA Energy Drink is a powerful blend of Branched-Chain Amino Acids (BCAAs), providing energy and supporting muscle recovery during workouts.", "BCAA Energy Drink", "35 JD", null },
                    { 6, "This Pre-Workout Nitric Oxide Booster is designed to enhance focus, increase energy levels, and improve blood flow for optimal workout performance.", "Pre-Workout Nitric Oxide Booster", "60 JD", null },
                    { 7, "Glutamine Capsules provide essential amino acids that aid in muscle recovery, immune system support, and reducing muscle soreness after intense workouts.", "Glutamine Capsules", "25 JD", null },
                    { 8, "Omega-3 Fish Oil supplements are rich in essential fatty acids that support cardiovascular health, joint function, and muscle recovery.", "Omega-3 Fish Oil", "45 JD", null },
                    { 9, "L-Carnitine Fat Burner helps convert stored body fat into energy, making it an effective supplement for those looking to manage weight and increase endurance.", "L-Carnitine Fat Burner", "55 JD", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69bdf35b-af27-421a-aa17-0c3cb3b8fa64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bb5804a-c312-493e-b8c0-92cea40dbb94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8299033-7c40-4f8e-8088-c46ba6e42ddc");

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "imageURL",
                table: "Gyms");

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
    }
}
