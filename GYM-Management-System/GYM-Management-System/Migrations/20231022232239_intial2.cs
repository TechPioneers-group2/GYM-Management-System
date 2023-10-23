using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class intial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13303c49-60c6-44e2-8f60-fd7952976fd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2dd6948-4082-4f0d-9ebb-08bf653d4e02");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "ba824617-021e-4ecd-b412-e2ff23178d34");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "ba824617-021e-4ecd-b412-e2ff23178d34");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "ba824617-021e-4ecd-b412-e2ff23178d34");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "ba824617-021e-4ecd-b412-e2ff23178d34");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "2d5ee3cf-a546-491e-b44e-d086c2101ea8");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "2d5ee3cf-a546-491e-b44e-d086c2101ea8");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "2d5ee3cf-a546-491e-b44e-d086c2101ea8");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "fafb1955-b447-4820-b79c-59a93bebe419");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "fafb1955-b447-4820-b79c-59a93bebe419");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d5ee3cf-a546-491e-b44e-d086c2101ea8", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" },
                    { "ba824617-021e-4ecd-b412-e2ff23178d34", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "fafb1955-b447-4820-b79c-59a93bebe419", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5abcff9-1d0a-4e38-8955-6cc5c74c0345", "AQAAAAIAAYagAAAAEFmHk8973iNTpT5M1XII2JsBpn6Fpl2tNGXIcynyU/z831vCRF/Kr4/mOSgC8NYxXg==", "d6c5d407-3466-4afc-83cc-79daf376b19d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79b9a422-1ed3-4950-a8da-a9214f09aeb0", "AQAAAAIAAYagAAAAEOl/Mfc8F1xDSJqD9Rci6Mxi2O1xJbkJ0uck5UhUjFsgGYUKUTt9vOGGGlCsL/54Pg==", "aa6deecc-6f93-4498-9e88-4e06441fb4b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5a2fa37-0c5d-472b-aad0-e7468b67dc6c", "AQAAAAIAAYagAAAAEB6s5OZVwgStmpLAFCzprMjrYUG+yhep+qWt0SKx/VC6LTdKYbniw7BUr0+luPjOqQ==", "aa5a14b1-b698-4868-83b6-d618fe826a23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b49570e4-cc91-4abb-b86e-16df96df3b46", "AQAAAAIAAYagAAAAEEORxcJLTXtkP0/HLBEG5TYNTrsi+wsEHBHGugN2XWiSO40BGVF1SWitSVrNM/BVZw==", "1793fb3a-135e-493a-9989-5eaa79719553" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 23, 2, 22, 39, 24, DateTimeKind.Local).AddTicks(9416), new DateTime(2024, 4, 23, 2, 22, 39, 24, DateTimeKind.Local).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 23, 2, 22, 39, 24, DateTimeKind.Local).AddTicks(9440), new DateTime(2024, 4, 23, 2, 22, 39, 24, DateTimeKind.Local).AddTicks(9440) });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 2,
                column: "PhotoUrl",
                value: "https://techpioneers.blob.core.windows.net/images/61cGWhpz3ZL._AC_UF10001000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3,
                column: "PhotoUrl",
                value: "https://techpioneers.blob.core.windows.net/images/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.webp");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "PhotoUrl",
                value: "https://techpioneers.blob.core.windows.net/images/bowflex-selecttech-552-dumbbell-weights-hero.webp");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5,
                column: "PhotoUrl",
                value: "https://techpioneers.blob.core.windows.net/images/precor-efx-635-elliptical_5000x.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d5ee3cf-a546-491e-b44e-d086c2101ea8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba824617-021e-4ecd-b412-e2ff23178d34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fafb1955-b447-4820-b79c-59a93bebe419");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "f2dd6948-4082-4f0d-9ebb-08bf653d4e02");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                column: "RoleId",
                value: "f2dd6948-4082-4f0d-9ebb-08bf653d4e02");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                column: "RoleId",
                value: "f2dd6948-4082-4f0d-9ebb-08bf653d4e02");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17,
                column: "RoleId",
                value: "13303c49-60c6-44e2-8f60-fd7952976fd6");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18,
                column: "RoleId",
                value: "13303c49-60c6-44e2-8f60-fd7952976fd6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13303c49-60c6-44e2-8f60-fd7952976fd6", "00000000-0000-0000-0000-000000000000", "Client", "CLIENT" },
                    { "6b449bbb-0fdf-42b0-92b2-0b9d2cf704de", "00000000-0000-0000-0000-000000000000", "Admin", "ADMIN" },
                    { "f2dd6948-4082-4f0d-9ebb-08bf653d4e02", "00000000-0000-0000-0000-000000000000", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1fe6810-8919-4e9c-b1b0-313e02c74808", "AQAAAAIAAYagAAAAENpi7P5aEFenGZFXoxQq9E7JjYBchgJbJYjn1Ru6+MwxNmojIsmTTraP2Q8F6DhUyQ==", "ddbb2429-4eea-457a-afce-90721dc829bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53024242-d950-4387-86db-0c4481166ff3", "AQAAAAIAAYagAAAAELI0i9mByEnJ2B4XgCp9h1MEnh3rKtjbQJzH1DGE0XuX/kbj1YxC8CMoZQl0k3wXsw==", "7d40b6ae-dc32-4eb5-8c05-71c53e7bf15b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9e48b94-480b-4257-909b-317e8c6cdf86", "AQAAAAIAAYagAAAAELPM+Vm3nxx+Rhv2WP2D7yGoE+Lf3F7W4AwZBBXpODulNcBCUiNbLcr2pC8UhxDbPQ==", "230c7c37-ec75-40c4-a421-69e2e3bd244f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef3b2055-8a11-41d2-b260-930026922581", "AQAAAAIAAYagAAAAEAsf+BHJbvLSYehTsGGhIcIVYnJbjpsIxGD00Hxyb5R8KoVFYhiBo8KgfnXu/dFibw==", "2ba842f7-142b-4d1d-9c56-4dd3de26311a" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 52, 8, 9, DateTimeKind.Local).AddTicks(7582), new DateTime(2024, 4, 21, 9, 52, 8, 9, DateTimeKind.Local).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 21, 9, 52, 8, 9, DateTimeKind.Local).AddTicks(7609), new DateTime(2024, 4, 21, 9, 52, 8, 9, DateTimeKind.Local).AddTicks(7610) });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 2,
                column: "PhotoUrl",
                value: "https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3,
                column: "PhotoUrl",
                value: "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "PhotoUrl",
                value: "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5,
                column: "PhotoUrl",
                value: "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733");
        }
    }
}
