using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitCatZafrazy.Migrations
{
    /// <inheritdoc />
    public partial class AddIndustryDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Industry",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Industry");
        }
    }
}
