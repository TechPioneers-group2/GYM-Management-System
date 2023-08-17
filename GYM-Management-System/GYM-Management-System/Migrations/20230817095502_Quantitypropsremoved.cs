using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class Quantitypropsremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GymSupplements_Supplements_SupplementID",
                table: "GymSupplements");

            migrationBuilder.DropIndex(
                name: "IX_GymSupplements_SupplementID",
                table: "GymSupplements");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Supplements");

            migrationBuilder.CreateTable(
                name: "GymSupplementSupplement",
                columns: table => new
                {
                    SupplementsSupplementID = table.Column<int>(type: "int", nullable: false),
                    GymSupplementsGymID = table.Column<int>(type: "int", nullable: false),
                    GymSupplementsSupplementID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymSupplementSupplement", x => new { x.SupplementsSupplementID, x.GymSupplementsGymID, x.GymSupplementsSupplementID });
                    table.ForeignKey(
                        name: "FK_GymSupplementSupplement_GymSupplements_GymSupplementsGymID_GymSupplementsSupplementID",
                        columns: x => new { x.GymSupplementsGymID, x.GymSupplementsSupplementID },
                        principalTable: "GymSupplements",
                        principalColumns: new[] { "GymID", "SupplementID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GymSupplementSupplement_Supplements_SupplementsSupplementID",
                        column: x => x.SupplementsSupplementID,
                        principalTable: "Supplements",
                        principalColumn: "SupplementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GymSupplementSupplement_GymSupplementsGymID_GymSupplementsSupplementID",
                table: "GymSupplementSupplement",
                columns: new[] { "GymSupplementsGymID", "GymSupplementsSupplementID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymSupplementSupplement");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GymSupplements_SupplementID",
                table: "GymSupplements",
                column: "SupplementID");

            migrationBuilder.AddForeignKey(
                name: "FK_GymSupplements_Supplements_SupplementID",
                table: "GymSupplements",
                column: "SupplementID",
                principalTable: "Supplements",
                principalColumn: "SupplementID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
