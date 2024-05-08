using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_NormalUserId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "NormalUserId",
                table: "ShoppingCarts",
                newName: "CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_NormalUserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_CustomerUserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f29c3b44-6ab5-4779-8885-70f6318456b1", "AQAAAAIAAYagAAAAELR5y5OIWRlPHmJ85yOr+U4S6+I57MqZ9O8VYiVdgV57I8rDX+B8mUeEH8OL816tEQ==", "115f0156-fa2c-41ab-a648-0567f1e280f3" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_CustomerUserId",
                table: "ShoppingCarts",
                column: "CustomerUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_CustomerUserId",
                table: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "ShoppingCarts",
                newName: "NormalUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCarts_CustomerUserId",
                table: "ShoppingCarts",
                newName: "IX_ShoppingCarts_NormalUserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba28b87f-3b4b-4ea4-845e-3182095e8256", "AQAAAAIAAYagAAAAEEmYxH3+l4AfiVwqlwNfsKkoWk4cv+Nndbo/s+0vuJjFwg7qBJDz2foebGPKcF9k4g==", "7380878d-f14b-45a2-acbd-fa1bd6c6de42" });

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_AspNetUsers_NormalUserId",
                table: "ShoppingCarts",
                column: "NormalUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
