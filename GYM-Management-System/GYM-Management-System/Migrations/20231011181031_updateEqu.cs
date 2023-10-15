using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updateEqu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "GymEquipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 2,
                column: "img",
                value: "https://m.media-amazon.com/images/I/61cGWhpz3ZL._AC_UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 3,
                columns: new[] { "OutOfService", "Quantity", "img" },
                values: new object[] { 2, 10, "https://shop.lifefitness.com/cdn/shop/products/clubseries-plus-treadmill-titanium-storm-se3hd-1000x1000_1800x1800.jpg?v=1678726811" });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                columns: new[] { "Quantity", "img" },
                values: new object[] { 60, "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit" });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5,
                column: "img",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnsPmSNYmymbPYugmtEjpmA3e_vdCya4td2Q&usqp=CAU");

            migrationBuilder.UpdateData(
                table: "Gyms",
                keyColumn: "GymID",
                keyValue: 3,
                column: "Notification",
                value: "Under maintenance until 9-9-2023 AD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "GymEquipments");

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
