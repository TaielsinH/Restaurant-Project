using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingWithImageFromGemini : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1559466273-d95e72debaf8?q=80&w=600");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "ImageUrl",
                value: "url_provoleta");
        }
    }
}
