using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NetCoreBase.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValue: "system"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CreatedBy = table.Column<string>(type: "text", nullable: false, defaultValue: "system"),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamptz", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "Price", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2025, 3, 28, 0, 4, 42, 698, DateTimeKind.Unspecified).AddTicks(8538), new TimeSpan(0, 0, 0, 0, 0)), "Seed Data 1 Description", "Seed Data 1", 5.5m, null },
                    { 2L, new DateTimeOffset(new DateTime(2025, 3, 28, 0, 4, 42, 698, DateTimeKind.Unspecified).AddTicks(8548), new TimeSpan(0, 0, 0, 0, 0)), "Seed Data 2 Description", "Seed Data 2", 10.5m, null }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Capacity", "CreatedAt", "Location", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 10000, new DateTimeOffset(new DateTime(2025, 3, 28, 0, 4, 42, 699, DateTimeKind.Unspecified).AddTicks(1734), new TimeSpan(0, 0, 0, 0, 0)), "México", "Warehouse 1", null },
                    { 2L, 100000, new DateTimeOffset(new DateTime(2025, 3, 28, 0, 4, 42, 699, DateTimeKind.Unspecified).AddTicks(1737), new TimeSpan(0, 0, 0, 0, 0)), "China", "Warehouse 2", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
