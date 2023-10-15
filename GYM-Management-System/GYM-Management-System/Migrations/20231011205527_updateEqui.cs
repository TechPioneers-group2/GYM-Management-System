using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class updateEqui : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5,
                column: "img",
                value: "https://www.precorhomefitness.com/cdn/shop/products/precor-efx-635-elliptical_5000x.jpg?v=1686422733");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 5,
                column: "img",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnsPmSNYmymbPYugmtEjpmA3e_vdCya4td2Q&usqp=CAU");
        }
    }
}
