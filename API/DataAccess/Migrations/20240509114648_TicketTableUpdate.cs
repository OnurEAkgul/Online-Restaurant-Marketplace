using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TicketTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TicketContext",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea7883fa-8fa3-4f4c-8b56-fad000383995", "AQAAAAIAAYagAAAAEMdFDQpczpotnfR49qokt8+K1Irbyl3gBr3AfjnMtUFQMVOlWNPXJDgq1PqRlXMYVA==", "c38573aa-5853-415e-a9a5-34a7a4858112" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketContext",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f29c3b44-6ab5-4779-8885-70f6318456b1", "AQAAAAIAAYagAAAAELR5y5OIWRlPHmJ85yOr+U4S6+I57MqZ9O8VYiVdgV57I8rDX+B8mUeEH8OL816tEQ==", "115f0156-fa2c-41ab-a648-0567f1e280f3" });
        }
    }
}
