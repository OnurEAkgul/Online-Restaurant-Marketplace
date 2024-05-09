using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TicketTableUpdate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketContextResponse",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SupportUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8754482-817c-4115-be72-7d9558939079", "AQAAAAIAAYagAAAAEMvO2DkqT5nPts7qy3034CwEBPCSGNMSOA9nM4g/kEJchDPwm5wAZKXJWXcOd6h9gA==", "9bab2205-0570-495d-8243-6a2e8cdb25db" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TicketContextResponse",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupportUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f0e702-5de4-4c6a-8e0c-a04e2116bda9", "AQAAAAIAAYagAAAAEGM5andMaYsO3Lki//urPBnM3SImql1ytvrpWSiZzYM559I11L/eLMFlTOYRPMUVLA==", "6f9d0574-3db7-4d41-8c09-628b7751ad30" });
        }
    }
}
