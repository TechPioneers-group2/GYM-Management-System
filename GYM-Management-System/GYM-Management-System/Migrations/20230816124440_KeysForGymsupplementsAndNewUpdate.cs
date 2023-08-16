using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class KeysForGymsupplementsAndNewUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymSupplement_Gyms_GymID",
                table: "GymSupplement");

            migrationBuilder.DropForeignKey(
                name: "FK_GymSupplement_Supplements_SupplementID",
                table: "GymSupplement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymSupplement",
                table: "GymSupplement");

            migrationBuilder.RenameTable(
                name: "GymSupplement",
                newName: "GymSupplements");

            migrationBuilder.RenameIndex(
                name: "IX_GymSupplement_SupplementID",
                table: "GymSupplements",
                newName: "IX_GymSupplements_SupplementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymSupplements",
                table: "GymSupplements",
                columns: new[] { "GymID", "SupplementID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GymSupplements_Gyms_GymID",
                table: "GymSupplements",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "GymID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymSupplements_Supplements_SupplementID",
                table: "GymSupplements",
                column: "SupplementID",
                principalTable: "Supplements",
                principalColumn: "SupplementID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymSupplements_Gyms_GymID",
                table: "GymSupplements");

            migrationBuilder.DropForeignKey(
                name: "FK_GymSupplements_Supplements_SupplementID",
                table: "GymSupplements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GymSupplements",
                table: "GymSupplements");

            migrationBuilder.RenameTable(
                name: "GymSupplements",
                newName: "GymSupplement");

            migrationBuilder.RenameIndex(
                name: "IX_GymSupplements_SupplementID",
                table: "GymSupplement",
                newName: "IX_GymSupplement_SupplementID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GymSupplement",
                table: "GymSupplement",
                columns: new[] { "GymID", "SupplementID" });

            migrationBuilder.AddForeignKey(
                name: "FK_GymSupplement_Gyms_GymID",
                table: "GymSupplement",
                column: "GymID",
                principalTable: "Gyms",
                principalColumn: "GymID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GymSupplement_Supplements_SupplementID",
                table: "GymSupplement",
                column: "SupplementID",
                principalTable: "Supplements",
                principalColumn: "SupplementID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
