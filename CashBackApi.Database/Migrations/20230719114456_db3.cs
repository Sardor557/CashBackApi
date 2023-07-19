using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income",
                table: "tb_cash_backs");

            migrationBuilder.DropColumn(
                name: "out_come",
                table: "tb_cash_backs");

            migrationBuilder.CreateTable(
                name: "tb_cash_back_balances",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    income = table.Column<long>(type: "bigint", nullable: false),
                    outcome = table.Column<long>(type: "bigint", nullable: false),
                    cash_back_id = table.Column<int>(type: "integer", nullable: false),
                    create_user = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_user = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_cash_back_balances", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_cash_back_balances_tb_cash_backs_cash_back_id",
                        column: x => x.cash_back_id,
                        principalTable: "tb_cash_backs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_tb_cash_back_balances_cash_back_id",
                table: "tb_cash_back_balances",
                column: "cash_back_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cash_back_balances");

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
    }
}
