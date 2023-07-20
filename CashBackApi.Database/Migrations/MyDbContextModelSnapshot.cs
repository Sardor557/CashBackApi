﻿// <auto-generated />
using System;
using CashBackApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashBackApi.Database.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CashBackApi.Models.spUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("CreateUser")
                        .HasColumnType("integer")
                        .HasColumnName("create_user");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("integer")
                        .HasColumnName("update_user");

                    b.HasKey("Id")
                        .HasName("pk_sp_user_types");

                    b.ToTable("sp_user_types", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2023, 7, 20, 11, 19, 32, 29, DateTimeKind.Local).AddTicks(1612),
                            CreateUser = 1,
                            Name = "Admin",
                            Status = 1
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2023, 7, 20, 11, 19, 32, 29, DateTimeKind.Local).AddTicks(1644),
                            CreateUser = 1,
                            Name = "Client",
                            Status = 1
                        });
                });

            modelBuilder.Entity("CashBackApi.Models.tbCashBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("CreateUser")
                        .HasColumnType("integer")
                        .HasColumnName("create_user");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<long>("TotalBalance")
                        .HasColumnType("bigint")
                        .HasColumnName("total_balance");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("integer")
                        .HasColumnName("update_user");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tb_cash_backs");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tb_cash_backs_user_id");

                    b.ToTable("tb_cash_backs", (string)null);
                });

            modelBuilder.Entity("CashBackApi.Models.tbCashBackBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CashBackId")
                        .HasColumnType("integer")
                        .HasColumnName("cash_back_id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("CreateUser")
                        .HasColumnType("integer")
                        .HasColumnName("create_user");

                    b.Property<long>("Income")
                        .HasColumnType("bigint")
                        .HasColumnName("income");

                    b.Property<long>("Outcome")
                        .HasColumnType("bigint")
                        .HasColumnName("outcome");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("integer")
                        .HasColumnName("update_user");

                    b.HasKey("Id")
                        .HasName("pk_tb_cash_back_balances");

                    b.HasIndex("CashBackId")
                        .HasDatabaseName("ix_tb_cash_back_balances_cash_back_id");

                    b.ToTable("tb_cash_back_balances", (string)null);
                });

            modelBuilder.Entity("CashBackApi.Models.tbSmsVerification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("CreateUser")
                        .HasColumnType("integer")
                        .HasColumnName("create_user");

                    b.Property<bool>("IsVerificated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_verificated");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("integer")
                        .HasColumnName("update_user");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_tb_sms_verifications");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_tb_sms_verifications_user_id");

                    b.ToTable("tb_sms_verifications", (string)null);
                });

            modelBuilder.Entity("CashBackApi.Models.tbUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<int>("CreateUser")
                        .HasColumnType("integer")
                        .HasColumnName("create_user");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("update_date");

                    b.Property<int?>("UpdateUser")
                        .HasColumnType("integer")
                        .HasColumnName("update_user");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("user_type_id");

                    b.HasKey("Id")
                        .HasName("pk_tb_users");

                    b.HasIndex("Phone")
                        .IsUnique()
                        .HasDatabaseName("ix_tb_users_phone");

                    b.HasIndex("UserTypeId")
                        .HasDatabaseName("ix_tb_users_user_type_id");

                    b.ToTable("tb_users", (string)null);
                });

            modelBuilder.Entity("CashBackApi.Models.tbCashBack", b =>
                {
                    b.HasOne("CashBackApi.Models.tbUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tb_cash_backs_tb_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CashBackApi.Models.tbCashBackBalance", b =>
                {
                    b.HasOne("CashBackApi.Models.tbCashBack", "CashBack")
                        .WithMany()
                        .HasForeignKey("CashBackId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tb_cash_back_balances_tb_cash_backs_cash_back_id");

                    b.Navigation("CashBack");
                });

            modelBuilder.Entity("CashBackApi.Models.tbSmsVerification", b =>
                {
                    b.HasOne("CashBackApi.Models.tbUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tb_sms_verifications_tb_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CashBackApi.Models.tbUser", b =>
                {
                    b.HasOne("CashBackApi.Models.spUserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("fk_tb_users_sp_user_types_user_type_id");

                    b.Navigation("UserType");
                });
#pragma warning restore 612, 618
        }
    }
}
