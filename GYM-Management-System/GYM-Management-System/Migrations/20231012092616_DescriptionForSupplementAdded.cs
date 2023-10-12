using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionForSupplementAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Supplements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 1,
                column: "Description",
                value: "Whey protein is a mixture of proteins isolated from whey, which is the liquid part of milk that separates during cheese production.\r\nMilk actually contains two main types of protein: casein (80%) and whey (20%).");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 2,
                column: "Description",
                value: "Creatine is a combination of three different amino acids: glycine, arginine, and methionine.");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 3,
                column: "Description",
                value: "Branched-Chain Amino Acids (BCAAs) are a group of three essential amino acids: leucine, isoleucine, and valine. They are called branched-chain because they are the only three amino acids to have a chain that branches off to one side.");

            migrationBuilder.UpdateData(
                table: "Supplements",
                keyColumn: "SupplementID",
                keyValue: 4,
                column: "Description",
                value: "A pre-workout blend is a class of powdered drink mixes that are consumed 20-30 minutes prior to the beginning of a rigorous workout to increase exercise performance. ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Supplements");

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
