using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class descriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2496ec85-dbe9-40e5-bdf9-8ab1dd978183", "AQAAAAIAAYagAAAAELMTZ81F/I5UeThoeedZNBZPD8LMprcwnYpVIvyux+cX0qDppR0p+i+QpzBBEfWtSg==", "788ff29d-8171-445b-b880-2ffbe8e94126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69d429ab-27d4-4f19-8caf-c0eebdaad0d5", "AQAAAAIAAYagAAAAEPPbHW1iGLEVRmJVXJsE3Ze4hZ81OkTamoQoJTQmlPx3Qy0LLmJ+HvDJOcyfsYc5cg==", "be50d559-4a89-4873-a042-53940f03b750" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10dde043-55df-4cab-bf53-b46e1b8a28e1", "AQAAAAIAAYagAAAAEL1zPL0ATpeh+A49RFc6FvK60PLjGt9kczDSyX3BKUiccW56zJS+YeUdz8hICsm1Cg==", "fcc069fb-fa92-41e7-a618-4df511ce891f" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 14, 21, 38, 58, 641, DateTimeKind.Local).AddTicks(8057), new DateTime(2024, 4, 14, 21, 38, 58, 641, DateTimeKind.Local).AddTicks(8066) });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "img",
                value: "https://www.bowflex.com/dw/image/v2/AAYW_PRD/on/demandware.static/-/Sites-nautilus-master-catalog/default/dwf21fb1cf/images/bfx/weights/100131/bowflex-selecttech-552-dumbbell-weights-hero.jpg?sw=2600&sh=1464&sm=fit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a0b4455-2f58-4777-a919-b7c710332938", "AQAAAAIAAYagAAAAECTyAS/oMp0mH7AeThUuP0iNUBd5a+KhYMOF1YwVsxINlCbZI3Ct20uhzDEeqrUsPQ==", "1f2a9f5d-0247-4fc2-96b8-a054328b8877" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63cf1300-13ce-40d3-a8ea-0a0105b3589f", "AQAAAAIAAYagAAAAEKV+7tj6Pmc0kJTmknpzZT3Azl7/eNQk+gIVhrR4I82SOr3qM7UoDPJMKkQ5vkZLBw==", "fd2f7db5-8839-4a1f-b7cf-3b447eefa407" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b75196b6-2a17-4c13-82dd-5b2ca83c381a", "AQAAAAIAAYagAAAAED1LP34E0AtQ+mPv8k7dCkOurKfRk7IHQIiQBb+YeIN4jbzV2nCzQFUdT09oOWoISw==", "f9b97d9b-d2df-4da8-9be5-b65f89698e1e" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "SubscriptionDate", "SubscriptionExpiry" },
                values: new object[] { new DateTime(2023, 10, 14, 13, 58, 41, 317, DateTimeKind.Local).AddTicks(1292), new DateTime(2024, 4, 14, 13, 58, 41, 317, DateTimeKind.Local).AddTicks(1304) });

            migrationBuilder.UpdateData(
                table: "GymEquipments",
                keyColumn: "GymEquipmentID",
                keyValue: 4,
                column: "img",
                value: null);
        }
    }
}
