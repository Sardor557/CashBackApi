using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cash_back",
                table: "tb_cash_backs",
                newName: "total_balance");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total_balance",
                table: "tb_cash_backs",
                newName: "cash_back");

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 16, 44, 56, 288, DateTimeKind.Local).AddTicks(4660));

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 16, 44, 56, 288, DateTimeKind.Local).AddTicks(4690));
        }
    }
}
