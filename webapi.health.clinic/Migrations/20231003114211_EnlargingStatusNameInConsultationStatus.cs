using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    /// <inheritdoc />
    public partial class EnlargingStatusNameInConsultationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "ConsultationStatus",
                type: "VARCHAR(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusName",
                table: "ConsultationStatus",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(32)");
        }
    }
}
