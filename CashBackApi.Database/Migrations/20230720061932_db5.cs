using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 11, 19, 32, 29, DateTimeKind.Local).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 11, 19, 32, 29, DateTimeKind.Local).AddTicks(1644));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 11, 15, 2, 462, DateTimeKind.Local).AddTicks(9950));

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date",
                value: new DateTime(2023, 7, 20, 11, 15, 2, 462, DateTimeKind.Local).AddTicks(9982));
        }
    }
}
