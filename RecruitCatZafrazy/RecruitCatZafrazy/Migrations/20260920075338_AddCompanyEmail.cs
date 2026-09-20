using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitCatZafrazy.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Company",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Company");
        }
    }
}
