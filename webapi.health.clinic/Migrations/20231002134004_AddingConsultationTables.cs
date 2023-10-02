using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health.clinic.Migrations
{
    /// <inheritdoc />
    public partial class AddingConsultationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultationStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusName = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "VARCHAR", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Time = table.Column<TimeSpan>(type: "Time", nullable: false),
                    ClinicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorMedicalSpecialtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultationStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_ConsultationStatus_ConsultationStatusId",
                        column: x => x.ConsultationStatusId,
                        principalTable: "ConsultationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_DoctorMedicalSpecialties_DoctorMedicalSpecialtyId",
                        column: x => x.DoctorMedicalSpecialtyId,
                        principalTable: "DoctorMedicalSpecialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Text = table.Column<string>(type: "VARCHAR(300)", maxLength: 300, nullable: false),
                    IsValidated = table.Column<bool>(type: "BIT", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ConsultationId",
                table: "Comments",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ClinicId",
                table: "Consultations",
                column: "ClinicId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_ConsultationStatusId",
                table: "Consultations",
                column: "ConsultationStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DoctorMedicalSpecialtyId",
                table: "Consultations",
                column: "DoctorMedicalSpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedicalRecordId",
                table: "Consultations",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "ConsultationStatus");

            migrationBuilder.DropTable(
                name: "MedicalRecords");
        }
    }
}
