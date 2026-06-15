using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KineticTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "password_hash",
                value: "aVZ5lhmja/hC7/cO/dMYWYOGfWYzFH4Is4X2UAazw9GRGBDCaaBdKcHUYP3TtXKo");

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "password_hash",
                value: "aVZ5lhmja/hC7/cO/dMYWYOGfWYzFH4Is4X2UAazw9GRGBDCaaBdKcHUYP3TtXKo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                column: "password_hash",
                value: "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G");

            migrationBuilder.UpdateData(
                table: "USERS",
                keyColumn: "user_id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b8c-9d0e-1f2a3b4c5d6e"),
                column: "password_hash",
                value: "$2a$11$EvX7FvY.bW2w8WvSgK6Oeeun7v6pMihV9b2XoA8JqfE3m8N56gZ6G");
        }
    }
}
