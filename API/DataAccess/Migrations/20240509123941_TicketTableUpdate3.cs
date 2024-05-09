using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TicketTableUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30f0e702-5de4-4c6a-8e0c-a04e2116bda9", "AQAAAAIAAYagAAAAEGM5andMaYsO3Lki//urPBnM3SImql1ytvrpWSiZzYM559I11L/eLMFlTOYRPMUVLA==", "6f9d0574-3db7-4d41-8c09-628b7751ad30" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tickets");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "863efe69-f50d-452d-a552-cd731c2998f5", "AQAAAAIAAYagAAAAEBrTlFQZcjKHQWzdAmK94MpmhhkgUs03Q07rUrlJKyeVlFK7SPaBvTkCPGTdTKsjNQ==", "0a59cf09-0037-4fcf-a8b9-b47c5080e8e1" });
        }
    }
}
