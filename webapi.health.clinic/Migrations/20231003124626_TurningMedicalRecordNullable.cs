using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    /// <inheritdoc />
    public partial class TurningMedicalRecordNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalRecordId",
                table: "Consultations",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalRecordId",
                table: "Consultations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                table: "Consultations",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
