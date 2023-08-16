using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class AddGymSupplementModelAndNewSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplements_Gyms_GymID",
                table: "Supplements");

            migrationBuilder.DropIndex(
                name: "IX_Supplements_GymID",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "GymID",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Supplements");

            migrationBuilder.CreateTable(
                name: "GymSupplement",
                columns: table => new
                {
                    SupplementID = table.Column<int>(type: "int", nullable: false),
                    GymID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSupplement", x => new { x.GymID, x.SupplementID });
                    table.ForeignKey(
                        name: "FK_GymSupplement_Gyms_GymID",
                        column: x => x.GymID,
                        principalTable: "Gyms",
                        principalColumn: "GymID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymSupplement_Supplements_SupplementID",
                        column: x => x.SupplementID,
                        principalTable: "Supplements",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "Name",
                value: "Ahmad Harhoosh");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "GymID", "InGym", "Name", "SubscriptionDate", "SubscriptionExpiry", "SubscriptionTierID" },
                values: new object[] { 2, 2, false, "Ammar Albisany", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1,
                columns: new[] { "ActiveHours", "Name" },
                values: new object[] { "5AM-12PM", "WillPower-Amman" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2,
                columns: new[] { "ActiveHours", "MaxCapacity", "Name" },
                values: new object[] { "6AM-12PM", "120", "WillPower-Zarqa" });

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 1,
                column: "Name",
                value: "1 month");

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "3 months", "60 JD" });

            migrationBuilder.InsertData(
                table: "SubscriptionTiers",
                columns: new[] { "SubscriptionTierID", "Length", "Name", "Price" },
                values: new object[] { 3, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "6 months", "110 JD" });

            migrationBuilder.CreateIndex(
                name: "IX_GymSupplement_SupplementID",
                table: "GymSupplement",
                column: "SupplementID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymSupplement");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "GymID",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Quantity",
                table: "Supplements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                column: "Name",
                value: "ammar");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 1,
                columns: new[] { "ActiveHours", "Name" },
                values: new object[] { "5AM-9PM", "GYM1" });

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 2,
                columns: new[] { "ActiveHours", "MaxCapacity", "Name" },
                values: new object[] { "5AM-9PM", "150", "GYM1" });

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 1,
                column: "Name",
                value: "3 months");

            migrationBuilder.UpdateData(
                table: "SubscriptionTiers",
                keyColumn: "SubscriptionTierID",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "6 months", "150 JD" });

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_GymID",
                table: "Supplements",
                column: "GymID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplements_Gyms_GymID",
                table: "Supplements",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "GymID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
