using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_WorkExperiences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkExperiences_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CreateDate", "Degree", "Description", "EndDate", "FieldOfStudy", "InstitutionName", "StartDate", "UserId" },
                values: new object[] { 1, new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7870), "Bachelor's", "", new DateOnly(2024, 7, 1), "Computer Engineering", "Jabarean ctiy", new DateOnly(2020, 9, 1), 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7751), new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7762) });

            migrationBuilder.InsertData(
                table: "WorkExperiences",
                columns: new[] { "Id", "CompanyName", "CreateDate", "Description", "EndDate", "JobTitle", "StartDate", "UserId" },
                values: new object[] { 1, "StartUp BlackVers", new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7988), "backend devloper asp.net core", new DateOnly(2024, 4, 1), "Backend Devloper", new DateOnly(2023, 2, 1), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_UserId",
                table: "WorkExperiences",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkExperiences");

            migrationBuilder.DeleteData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 17, 46, 16, 358, DateTimeKind.Local).AddTicks(6016));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 25, 17, 46, 16, 358, DateTimeKind.Local).AddTicks(5878), new DateTime(2024, 7, 25, 17, 46, 16, 358, DateTimeKind.Local).AddTicks(5893) });
        }
    }
}
