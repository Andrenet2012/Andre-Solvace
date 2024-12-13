using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Solvace.TechCase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class NovaTableProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExternalId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7692), new TimeSpan(0, 0, 0, 0, 0)), "ced0d0a2-24b6-428a-8f83-736f78ebb65c" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7798), new TimeSpan(0, 0, 0, 0, 0)), "9a9a147c-cb8b-4bb6-b683-0690a43689fc" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 29, 3, 59, 15, 567, DateTimeKind.Unspecified).AddTicks(7824), new TimeSpan(0, 0, 0, 0, 0)), "42da6666-0a9d-4249-9655-f924ed681968" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 28, 11, 35, 7, 830, DateTimeKind.Unspecified).AddTicks(58), new TimeSpan(0, 0, 0, 0, 0)), "373cb3b4-26d7-4453-b674-7dd880e2bb24" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 28, 11, 35, 7, 830, DateTimeKind.Unspecified).AddTicks(284), new TimeSpan(0, 0, 0, 0, 0)), "971235ab-5205-4a19-84ca-6cae1750d06a" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 28, 11, 35, 7, 830, DateTimeKind.Unspecified).AddTicks(340), new TimeSpan(0, 0, 0, 0, 0)), "7ea86957-0b1d-4491-b8c7-808e3592389e" });
        }
    }
}
