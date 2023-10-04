using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    /// <inheritdoc />
    public partial class AdaptingUserForHashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Users",
                type: "BINARY(32)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Users",
                type: "BINARY(16)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");
        }
    }
}
