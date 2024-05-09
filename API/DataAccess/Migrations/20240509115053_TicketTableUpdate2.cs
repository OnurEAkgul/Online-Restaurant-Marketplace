using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TicketTableUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketContextResponse",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketContextResponse",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea7883fa-8fa3-4f4c-8b56-fad000383995", "AQAAAAIAAYagAAAAEMdFDQpczpotnfR49qokt8+K1Irbyl3gBr3AfjnMtUFQMVOlWNPXJDgq1PqRlXMYVA==", "c38573aa-5853-415e-a9a5-34a7a4858112" });
        }
    }
}
