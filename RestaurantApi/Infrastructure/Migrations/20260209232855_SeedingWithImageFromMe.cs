using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingWithImageFromMe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "Description",
                value: "https://cdn.shopify.com/s/files/1/0097/7892/1572/files/SvRumKBuh_2000x1500__1.jpg?v=1741958041");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                column: "Description",
                value: "Queso provolone fundido a la parrilla con orégano, aceite de oliva y rodajas de tomate asado.");
        }
    }
}
