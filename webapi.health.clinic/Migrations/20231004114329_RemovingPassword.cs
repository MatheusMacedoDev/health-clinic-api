using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    /// <inheritdoc />
    public partial class RemovingPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "CHAR(60)",
                nullable: false,
                defaultValue: "");
        }
    }
}
