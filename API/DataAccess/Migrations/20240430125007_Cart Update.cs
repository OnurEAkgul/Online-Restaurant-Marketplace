using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CartUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed4ab13a-fa0e-40bf-a43b-0beaa57d7236", "AQAAAAIAAYagAAAAEOwVlepPAvAgoeNqqhppN39QA4/5lqonSIOSBdNyOlhaDQw5k5dh+DRfv3lgJ73/2Q==", "e37ca5c2-6e02-4f90-a676-e553c635921c" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Product_ProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9acbb401-b8ae-4ec8-9286-29e6dae86360",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f247bf3-3112-4eb7-a804-356aaf55933e", "AQAAAAIAAYagAAAAEGCaC5DQ6/TuBZew67O7QZgHeJsvKqQS3v6rl5vsVNqbrvZNtB6UORh4RRntprXQwA==", "a340c128-1ab1-4e65-8f4b-281be293a38b" });
        }
    }
}
