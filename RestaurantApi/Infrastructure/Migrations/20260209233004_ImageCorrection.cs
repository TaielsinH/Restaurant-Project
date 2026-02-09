using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "Queso provolone fundido a la parrilla con orégano, aceite de oliva y rodajas de tomate asado.", "https://cdn.shopify.com/s/files/1/0097/7892/1572/files/SvRumKBuh_2000x1500__1.jpg?v=1741958041" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"),
                columns: new[] { "Description", "ImageUrl" },
                values: new object[] { "https://cdn.shopify.com/s/files/1/0097/7892/1572/files/SvRumKBuh_2000x1500__1.jpg?v=1741958041", "https://images.unsplash.com/photo-1559466273-d95e72debaf8?q=80&w=600" });
        }
    }
}
