using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sp_user_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    create_user = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_user = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sp_user_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: false),
                    login = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    user_type_id = table.Column<int>(type: "integer", nullable: false),
                    create_user = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_user = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_users_sp_user_types_user_type_id",
                        column: x => x.user_type_id,
                        principalTable: "sp_user_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_cash_backs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    cash_back = table.Column<long>(type: "bigint", nullable: false),
                    create_user = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_user = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_cash_backs", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_cash_backs_tb_users_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_sms_verifications",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<int>(type: "integer", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    is_verificated = table.Column<bool>(type: "boolean", nullable: false),
                    create_user = table.Column<int>(type: "integer", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    update_user = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_sms_verifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_sms_verifications_tb_users_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "sp_user_types",
                columns: new[] { "id", "create_date", "create_user", "name", "status", "update_date", "update_user" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 19, 11, 6, 12, 559, DateTimeKind.Local).AddTicks(6094), 1, "Admin", 1, null, null },
                    { 2, new DateTime(2023, 7, 19, 11, 6, 12, 559, DateTimeKind.Local).AddTicks(6128), 1, "Client", 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_tb_cash_backs_user_id",
                table: "tb_cash_backs",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tb_sms_verifications_user_id",
                table: "tb_sms_verifications",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_tb_users_phone",
                table: "tb_users",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tb_users_user_type_id",
                table: "tb_users",
                column: "user_type_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_cash_backs");

            migrationBuilder.DropTable(
                name: "tb_sms_verifications");

            migrationBuilder.DropTable(
                name: "tb_users");

            migrationBuilder.DropTable(
                name: "sp_user_types");
        }
    }
}
