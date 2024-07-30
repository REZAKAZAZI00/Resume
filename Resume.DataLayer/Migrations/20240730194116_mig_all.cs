using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 30, 23, 11, 15, 574, DateTimeKind.Local).AddTicks(385));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 30, 23, 11, 15, 574, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 30, 23, 11, 15, 574, DateTimeKind.Local).AddTicks(287), new DateTime(2024, 7, 30, 23, 11, 15, 574, DateTimeKind.Local).AddTicks(288) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 30, 23, 11, 15, 574, DateTimeKind.Local).AddTicks(526));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 27, 21, 37, 53, 412, DateTimeKind.Local).AddTicks(6014));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 27, 21, 37, 53, 412, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 27, 21, 37, 53, 412, DateTimeKind.Local).AddTicks(5897), new DateTime(2024, 7, 27, 21, 37, 53, 412, DateTimeKind.Local).AddTicks(5898) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 27, 21, 37, 53, 412, DateTimeKind.Local).AddTicks(6180));
        }
    }
}
