using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KineticTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "APPOINTMENTS",
                columns: table => new
                {
                    appointment_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    scheduled_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    patient_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    practitioner_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    care_episode_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "fk_appointments_care_episodes_care_episode_id",
                        column: x => x.care_episode_id,
                        principalTable: "CARE_EPISODE",
                        principalColumn: "care_episode_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "PATIENTS",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_appointments_practitioners_practitioner_id",
                        column: x => x.practitioner_id,
                        principalTable: "PRACTITIONERS",
                        principalColumn: "practitioner_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_appointments_care_episode_id",
                table: "APPOINTMENTS",
                column: "care_episode_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_patient_id",
                table: "APPOINTMENTS",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_appointments_practitioner_id",
                table: "APPOINTMENTS",
                column: "practitioner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPOINTMENTS");
        }
    }
}
