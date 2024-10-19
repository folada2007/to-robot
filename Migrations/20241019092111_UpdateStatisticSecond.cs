using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStatisticSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "staticsDb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "staticsDb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
