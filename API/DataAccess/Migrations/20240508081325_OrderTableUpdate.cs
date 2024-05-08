using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class OrderTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_NormalUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "NormalUserId",
                table: "Orders",
                newName: "CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_NormalUserId",
                table: "Orders",
                newName: "IX_Orders_CustomerUserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba28b87f-3b4b-4ea4-845e-3182095e8256", "AQAAAAIAAYagAAAAEEmYxH3+l4AfiVwqlwNfsKkoWk4cv+Nndbo/s+0vuJjFwg7qBJDz2foebGPKcF9k4g==", "7380878d-f14b-45a2-acbd-fa1bd6c6de42" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerUserId",
                table: "Orders",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerUserId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "Orders",
                newName: "NormalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerUserId",
                table: "Orders",
                newName: "IX_Orders_NormalUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5a8b3c8-95cc-410d-8473-459fd334c977", "AQAAAAIAAYagAAAAECBtPIPgNwH5Prrz4jSjKofE/D5u95lFH0a7jAtovPxuL4oYcKue7v6j/MEu7mG/UQ==", "77a0ef94-8653-4088-9ace-7ac984e6250b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_NormalUserId",
                table: "Orders",
                column: "NormalUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
