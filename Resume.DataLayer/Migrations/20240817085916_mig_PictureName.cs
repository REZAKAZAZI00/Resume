using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Resume.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_PictureName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "CategoryBlogs",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "CategoryBlogs");
        }
    }
}
