using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    public partial class db2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "income",
                table: "tb_cash_backs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "out_come",
                table: "tb_cash_backs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 14, 18, 4, 627, DateTimeKind.Local).AddTicks(4500));

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 14, 18, 4, 627, DateTimeKind.Local).AddTicks(4536));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income",
                table: "tb_cash_backs");

            migrationBuilder.DropColumn(
                name: "out_come",
                table: "tb_cash_backs");

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 1,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 11, 6, 12, 559, DateTimeKind.Local).AddTicks(6094));

            migrationBuilder.UpdateData(
                table: "sp_user_types",
                keyColumn: "id",
                keyValue: 2,
                column: "create_date",
                value: new DateTime(2023, 7, 19, 11, 6, 12, 559, DateTimeKind.Local).AddTicks(6128));
        }
    }
}
