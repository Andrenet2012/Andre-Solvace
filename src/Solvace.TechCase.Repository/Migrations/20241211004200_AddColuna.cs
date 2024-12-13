using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA0104 // Prefer jagged arrays over multidimensional

namespace Solvace.TechCase.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "ActionPlans",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "TypeName",
               table: "ActionPlans");

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2160), new TimeSpan(0, 0, 0, 0, 0)), "17b7b9ca-f00c-4567-8023-47e1c8f80971" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2270), new TimeSpan(0, 0, 0, 0, 0)), "ce5dd49b-85e9-40d0-87fa-e47327e382bf" });

            migrationBuilder.UpdateData(
                table: "ActionPlanStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "ExternalId" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 11, 4, 13, 27, 24, 538, DateTimeKind.Unspecified).AddTicks(2310), new TimeSpan(0, 0, 0, 0, 0)), "8203c033-f38c-4c94-9686-a5b0d27d98d0" });
        }
    }
}
