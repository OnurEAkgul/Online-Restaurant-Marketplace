using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Tickettableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0f917b4-69de-4132-ba17-14ce6d4c2ff7", "AQAAAAIAAYagAAAAEEK77BKrnLVgq7NGL17c3zvxPP1agEwvQHvBFFYdxqtAHmtwBD6rn13eoaXuKTD/6g==", "38f65285-bfa1-4af8-8edd-014f48108929" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CustomerUserId",
                table: "Tickets",
                column: "CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_CustomerUserId",
                table: "Tickets",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_CustomerUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_CustomerUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CustomerUserId",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4ab13a-fa0e-40bf-a43b-0beaa57d7236", "AQAAAAIAAYagAAAAEOwVlepPAvAgoeNqqhppN39QA4/5lqonSIOSBdNyOlhaDQw5k5dh+DRfv3lgJ73/2Q==", "e37ca5c2-6e02-4f90-a676-e553c635921c" });
        }
    }
}
