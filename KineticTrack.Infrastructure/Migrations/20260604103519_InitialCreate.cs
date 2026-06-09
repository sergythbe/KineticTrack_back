using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KineticTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "user_id", "created_at", "email", "firstname", "is_active", "is_deleted", "is_password_changed", "lastname", "password_hash" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"), new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc), "admin@kinetictrack.be", "Admin", true, false, true, "KineticTrack", "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G" },
                    { new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"), new DateTime(2026, 6, 4, 10, 9, 27, 355, DateTimeKind.Utc), "marie@kinetictrack.be", "Marie", true, false, true, "Secrétaire", "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G" }
                });

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
                name: "USERS");
        }
    }
}
