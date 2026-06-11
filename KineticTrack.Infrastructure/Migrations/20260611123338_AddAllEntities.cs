using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KineticTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CABINET",
                columns: table => new
                {
                    cabinet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cabinet", x => x.cabinet_id);
                });

            migrationBuilder.CreateTable(
                name: "EXERCISE_LIBRARY",
                columns: table => new
                {
                    exercise_library_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    media_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_library", x => x.exercise_library_id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_password_changed = table.Column<bool>(type: "bit", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "CABINET_MEMBER",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cabinet_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_at_cabinet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_owner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cabinet_member", x => new { x.user_id, x.cabinet_id });
                    table.ForeignKey(
                        name: "fk_cabinet_member_cabinet_cabinet_id",
                        column: x => x.cabinet_id,
                        principalTable: "CABINET",
                        principalColumn: "cabinet_id");
                    table.ForeignKey(
                        name: "fk_cabinet_member_users_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PATIENTS",
                columns: table => new
                {
                    patient_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    medical_history = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patients", x => x.patient_id);
                    table.ForeignKey(
                        name: "fk_patients_users_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRACTITIONERS",
                columns: table => new
                {
                    practitioner_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    license_number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    speciality = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_practitioners", x => x.practitioner_id);
                    table.ForeignKey(
                        name: "fk_practitioners_users_user_id",
                        column: x => x.user_id,
                        principalTable: "USERS",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARE_EPISODE",
                columns: table => new
                {
                    care_episode_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    patient_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_care_episode", x => x.care_episode_id);
                    table.ForeignKey(
                        name: "fk_care_episode_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "PATIENTS",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PROTOCOL",
                columns: table => new
                {
                    protocol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    care_episode_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_protocol", x => x.protocol_id);
                    table.ForeignKey(
                        name: "fk_protocol_care_episode_care_episode_id",
                        column: x => x.care_episode_id,
                        principalTable: "CARE_EPISODE",
                        principalColumn: "care_episode_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACTIVITY_LOG",
                columns: table => new
                {
                    activity_log_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    execution_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_completed = table.Column<bool>(type: "bit", nullable: false),
                    patient_comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    eva_metric = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    practitioner_note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    exercise_library_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    protocol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    patient_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_activity_log", x => x.activity_log_id);
                    table.ForeignKey(
                        name: "fk_activity_log_exercise_libraries_exercise_library_id",
                        column: x => x.exercise_library_id,
                        principalTable: "EXERCISE_LIBRARY",
                        principalColumn: "exercise_library_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_activity_log_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "PATIENTS",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_activity_log_protocols_protocol_id",
                        column: x => x.protocol_id,
                        principalTable: "PROTOCOL",
                        principalColumn: "protocol_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROTOCOL_EXERCISE",
                columns: table => new
                {
                    protocol_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    exercise_library_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parameters = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    order = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_protocol_exercise", x => new { x.protocol_id, x.exercise_library_id });
                    table.ForeignKey(
                        name: "fk_protocol_exercise_exercise_library_exercise_library_id",
                        column: x => x.exercise_library_id,
                        principalTable: "EXERCISE_LIBRARY",
                        principalColumn: "exercise_library_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_protocol_exercise_protocol_protocol_id",
                        column: x => x.protocol_id,
                        principalTable: "PROTOCOL",
                        principalColumn: "protocol_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CABINET",
                columns: new[] { "cabinet_id", "address", "name" },
                values: new object[] { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), "Rue de la Santé 1, 6000 Charleroi", "Cabinet KineticTrack" });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "user_id", "created_at", "email", "firstname", "is_active", "is_deleted", "is_password_changed", "lastname", "password_hash" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc), "admin@kinetictrack.be", "Admin", true, false, true, "KineticTrack", "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G" },
                    { new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc), "marie@kinetictrack.be", "Marie", true, false, true, "Secrétaire", "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G" }
                });

            migrationBuilder.InsertData(
                table: "CABINET_MEMBER",
                columns: new[] { "cabinet_id", "user_id", "is_owner", "role_at_cabinet" },
                values: new object[,]
                {
                    { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), true, "Admin" },
                    { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), false, "Secretaire" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_activity_log_exercise_library_id",
                table: "ACTIVITY_LOG",
                column: "exercise_library_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_log_patient_id",
                table: "ACTIVITY_LOG",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_activity_log_protocol_id",
                table: "ACTIVITY_LOG",
                column: "protocol_id");

            migrationBuilder.CreateIndex(
                name: "ix_cabinet_member_cabinet_id",
                table: "CABINET_MEMBER",
                column: "cabinet_id");

            migrationBuilder.CreateIndex(
                name: "ix_care_episode_patient_id",
                table: "CARE_EPISODE",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_patients_user_id",
                table: "PATIENTS",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_practitioners_user_id",
                table: "PRACTITIONERS",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_protocol_care_episode_id",
                table: "PROTOCOL",
                column: "care_episode_id");

            migrationBuilder.CreateIndex(
                name: "ix_protocol_exercise_exercise_library_id",
                table: "PROTOCOL_EXERCISE",
                column: "exercise_library_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "USERS",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACTIVITY_LOG");

            migrationBuilder.DropTable(
                name: "CABINET_MEMBER");

            migrationBuilder.DropTable(
                name: "PRACTITIONERS");

            migrationBuilder.DropTable(
                name: "PROTOCOL_EXERCISE");

            migrationBuilder.DropTable(
                name: "CABINET");

            migrationBuilder.DropTable(
                name: "EXERCISE_LIBRARY");

            migrationBuilder.DropTable(
                name: "PROTOCOL");

            migrationBuilder.DropTable(
                name: "CARE_EPISODE");

            migrationBuilder.DropTable(
                name: "PATIENTS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
