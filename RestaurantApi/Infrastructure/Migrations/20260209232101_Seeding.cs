using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "DishId", "Available", "Category", "CreateDate", "Description", "ImageUrl", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111101"), true, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Clásica empanada frita rellena de carne cortada a cuchillo, huevo y cebolla de verdeo.", "https://images.unsplash.com/photo-1619926340139-9a2e2245a64e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZW1wYW5hZGElMjBhcmdlbnRpbmF8ZW58MHx8MHx8fDA%3D", "Empanada de Carne Cortada a Cuchillo", 1500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("11111111-1111-1111-1111-111111111102"), true, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Queso provolone fundido a la parrilla con orégano, aceite de oliva y rodajas de tomate asado.", "url_provoleta", "Provoleta Especial", 6500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("11111111-1111-1111-1111-111111111103"), true, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Anillos de calamar rebozados y fritos, servidos con limón y salsa tártara.", "url_rabas", "Rabas a la Romana", 9000.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111101"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111102"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"));
        }
    }
}
