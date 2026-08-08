using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KineticTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameCabinetRoleEnumValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CABINET_MEMBER",
                keyColumns: new[] { "cabinet_id", "user_id" },
                keyValues: new object[] { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e") },
                column: "role_at_cabinet",
                value: "Secretary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CABINET_MEMBER",
                keyColumns: new[] { "cabinet_id", "user_id" },
                keyValues: new object[] { new Guid("c3d4e5f6-a7b8-4c9d-0e1f-2a3b4c5d6e7f"), new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e") },
                column: "role_at_cabinet",
                value: "Secretaire");
        }
    }
}
