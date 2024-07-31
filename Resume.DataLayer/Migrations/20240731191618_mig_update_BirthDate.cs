using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_BirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreateDate", "Email", "FirstName", "IaActive", "LastName", "Password", "Phone" },
                values: new object[] { 1, new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2011), new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2012), "rezakazazy8@yahoo.com", "reza", true, "Kazazi", "5600715f42bf51c40dc330d750cd996f58fead4ddea56466ce7498d17801b3a5", "09389253640" });

            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "Bio", "CreateDate", "Location", "PictureName", "Position", "UserId" },
                values: new object[] { 1, "my name is reza kazazi", new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2134), "", "", null, 1 });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreateDate", "Degree", "Description", "EndDate", "FieldOfStudy", "InstitutionName", "StartDate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2159), "Bachelor's", "", new DateOnly(2024, 7, 1), "Computer Engineering", "Jabarean ctiy", new DateOnly(2020, 9, 1), 1 });

            migrationBuilder.InsertData(
                table: "WorkExperiences",
                columns: new[] { "Id", "CompanyName", "CreateDate", "Description", "EndDate", "JobTitle", "StartDate", "UserId" },
                values: new object[] { 1, "StartUp BlackVers", new DateTime(2024, 7, 31, 13, 1, 12, 101, DateTimeKind.Local).AddTicks(2354), "backend devloper asp.net core", new DateOnly(2024, 4, 1), "Backend Devloper", new DateOnly(2023, 2, 1), 1 });
        }
    }
}
