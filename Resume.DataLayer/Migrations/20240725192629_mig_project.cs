using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 22, 56, 28, 501, DateTimeKind.Local).AddTicks(5721));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 22, 56, 28, 501, DateTimeKind.Local).AddTicks(5744));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 25, 22, 56, 28, 501, DateTimeKind.Local).AddTicks(5599), new DateTime(2024, 7, 25, 22, 56, 28, 501, DateTimeKind.Local).AddTicks(5612) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 22, 56, 28, 501, DateTimeKind.Local).AddTicks(5887));

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CategoryId",
                table: "Projects",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AboutMe",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7853));

            migrationBuilder.UpdateData(
                table: "Educations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7870));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreateDate" },
                values: new object[] { new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7751), new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "WorkExperiences",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 25, 19, 38, 17, 841, DateTimeKind.Local).AddTicks(7988));
        }
    }
}
