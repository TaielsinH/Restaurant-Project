using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2025/03/04/VN1snF0v2_1256x620__2.jpg#1741097857035");

            migrationBuilder.InsertData(
                table: "Dish",
                columns: new[] { "DishId", "Available", "Category", "CreateDate", "Description", "ImageUrl", "Name", "Price", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-2222-2222-222222222201"), true, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lechuga fresca, croutons, queso parmesano en hebras, pechuga de pollo grillada y aderezo Caesar.", "https://plus.unsplash.com/premium_photo-1700089483464-4f76cc3d360b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8c2FsYWQlMjBjYWVzYXJ8ZW58MHx8MHx8fDA%3D", "Ensalada Caesar con Pollo", 7800.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222202"), true, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Hojas de rúcula selvática, tomates secos hidratados y láminas de queso parmesano.", "https://imag.bonviveur.com/ensalada-de-rucula_1000.webp", "Ensalada de Rúcula y Parmesano", 7200.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333301"), true, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Milanesa de ternera cubierta con salsa de tomate, jamón y abundante muzzarella. Acompañada de papas bastón.", "https://www.lanacion.com.ar/resizer/v2/milanesa-a-la-napolitana-con-guarnicion-de-papas-VLWFAANIWBGPFO4CSUHS7RYVVQ.jpg?auth=335fda04cf2733e39d11ca0ba979c1d0a8a55e6cdec15e4d5b00cfd59fbf9ed8&width=880&height=586&quality=70&smart=true", "Milanesa a la Napolitana con Fritas", 11500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333302"), true, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tortilla de papas con cebolla y chorizo colorado. Punto babé.", "https://www.lanacion.com.ar/resizer/v2/tortilla-de-OGZW2PTYC5G6BESKCCDVFU3SDA.jpg?auth=3fba4327702c5439286db1f399c437a61c2c77afba59e23816800e6ceb27e85f&width=880&height=586&quality=70&smart=true", "Tortilla de Papas Española", 8500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("33333333-3333-3333-3333-333333333303"), true, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Suprema de pollo con salsa de choclo, banana frita y papas pay.", "url_maryland", "Suprema Maryland", 12000.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("44444444-4444-4444-4444-444444444401"), true, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sorrentinos caseros rellenos de jamón cocido y muzzarella con salsa a elección (Fileto, Crema o Mixta).", "url_sorrentinos", "Sorrentinos de Jamón y Queso", 9500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("44444444-4444-4444-4444-444444444402"), true, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Los clásicos del 29. Ñoquis de papa servidos con estofado de carne.", "url_noquis", "Ñoquis de Papa Caseros", 8900.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555501"), true, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Costillar de ternera cortado transversalmente, asado a fuego lento. Incluye guarnición.", "url_asado", "Asado de Tira", 14500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555502"), true, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Corte ancho y jugoso de bife de chorizo, punto a elección.", "url_bife_chorizo", "Bife de Chorizo (400g)", 16000.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-555555555503"), true, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Matambre de ternera tierno con salsa de tomate y queso muzzarella, finalizado a la parrilla.", "url_matambre", "Matambre a la Pizza", 15500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("66666666-6666-6666-6666-666666666601"), true, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Salsa de tomate casera, abundante muzzarella, orégano y aceitunas verdes.", "url_pizza_muzza", "Pizza Muzzarella Grande", 8000.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("66666666-6666-6666-6666-666666666602"), true, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Muzzarella, jamón cocido natural y tiras de morrones asados.", "url_pizza_especial", "Pizza Especial con Jamón y Morrones", 9500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("77777777-7777-7777-7777-777777777701"), true, 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lomo de ternera en pan francés con lechuga, tomate, jamón, queso y huevo frito. Sale con papas.", "url_lomito", "Lomito Completo", 10500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("77777777-7777-7777-7777-777777777702"), true, 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Doble medallón de carne (240g), doble cheddar, panceta crocante y cebolla caramelizada.", "url_hamburguesa", "Hamburguesa Doble Cheddar", 9800.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("88888888-8888-8888-8888-888888888801"), true, 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Línea Coca-Cola o Pepsi según disponibilidad.", "url_gaseosa", "Gaseosa Cola 500ml", 2500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("88888888-8888-8888-8888-888888888802"), true, 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Villavicencio o Eco de los Andes.", "url_agua", "Agua Mineral sin Gas 500ml", 2200.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("99999999-9999-9999-9999-999999999901"), true, 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cerveza Indian Pale Ale, amargor intenso y notas cítricas.", "url_ipa", "Pinta IPA", 4500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("99999999-9999-9999-9999-999999999902"), true, 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cerveza rubia suave con un toque de miel.", "url_honey", "Pinta Honey", 4500.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"), true, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flan de huevo tradicional acompañado de dulce de leche y crema chantilly.", "url_flan", "Flan Casero Mixto", 4200.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"), true, 10, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Panqueque tibio relleno con abundante dulce de leche repostero.", "url_panqueque", "Panqueque de Dulce de Leche", 4000.00m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222201"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222202"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333301"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333302"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444401"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444402"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555501"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555502"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555503"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666601"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666602"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777701"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777702"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888801"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888802"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999901"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999902"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"));

            migrationBuilder.DeleteData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"));

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111103"),
                column: "ImageUrl",
                value: "url_rabas");
        }
    }
}
