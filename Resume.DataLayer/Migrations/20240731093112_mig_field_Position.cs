using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_field_Position : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AboutMe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Position" },
                values: new object[] { new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2134), null });

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2011), new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2012) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2354));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "AboutMe");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 31, 0, 35, 39, 517, DateTimeKind.Local).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 31, 0, 35, 39, 517, DateTimeKind.Local).AddTicks(9277));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 31, 0, 35, 39, 517, DateTimeKind.Local).AddTicks(8744), new DateTime(2024, 7, 31, 0, 35, 39, 517, DateTimeKind.Local).AddTicks(8746) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 31, 0, 35, 39, 517, DateTimeKind.Local).AddTicks(9549));
        }
    }
}
