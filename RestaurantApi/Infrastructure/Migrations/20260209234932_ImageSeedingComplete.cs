using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageSeedingComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2024/08/09/SQrN6GsGV_1256x620__3.jpg#1742234090144");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444401"),
                column: "ImageUrl",
                value: "https://imag.bonviveur.com/sorrentinos-rellenos-de-jamon-y-queso-con-salsa-marinara_1000.webp");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444402"),
                column: "ImageUrl",
                value: "https://cocinalocal.cl/wp-content/uploads/2022/11/Noquis-de-papa-italianos.jpeg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555501"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2022/03/07/0w2kcAVNO_360x240__1.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555502"),
                column: "ImageUrl",
                value: "https://media.elgourmet.com/recetas/cover/bife-_UPgMoHqWDK4R60cwJ8hZVk2izxe71l.png");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555503"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2022/11/25/tR-l3EmRl_1256x620__2.jpg#1669400323977");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666601"),
                column: "ImageUrl",
                value: "https://www.laespanolaaceites.com/wp-content/uploads/2019/06/pizza-con-tomate-albahaca-y-mozzarella-1080x671.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666602"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2021/11/16/YcExTBfAe_360x240__1.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777701"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2021/07/26/u-aUfp64d_360x240__1.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777702"),
                column: "ImageUrl",
                value: "https://stordfkenticomedia.blob.core.windows.net/df-us/rms/media/recipemediafiles/recipe%20images%20and%20files/retail/desktop%20(600x600)/2023.nov/2023_retail_double-stack-cheeseburger_600x600.jpg?ext=.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888801"),
                column: "ImageUrl",
                value: "https://jumboargentina.vtexassets.com/arquivos/ids/782824-800-600?v=638206689771200000&width=800&height=600&aspect=true");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888802"),
                column: "ImageUrl",
                value: "https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3040341_f.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999901"),
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/3/32/Fuller%27s_India_pale_ale.jpg");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999902"),
                column: "ImageUrl",
                value: "https://cheverry.com.ar/wp-content/uploads/2020/07/okeoke1-5a2cab20b894ce672315277681133744-1024-1024.png");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                column: "ImageUrl",
                value: "https://www.infobae.com/resizer/v2/AR65PTXNQVEAVLYJPDI4LHMHY4.png?auth=2233aa8ae743a1e4dce47a982f5d0ceb147b2f309d8b0f6cb71e76d639b40f08&smart=true&width=1024&height=512&quality=85");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"),
                column: "ImageUrl",
                value: "https://www.clarin.com/img/2023/04/20/FH-fEx20c_1256x620__2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("33333333-3333-3333-3333-333333333303"),
                column: "ImageUrl",
                value: "url_maryland");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444401"),
                column: "ImageUrl",
                value: "url_sorrentinos");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("44444444-4444-4444-4444-444444444402"),
                column: "ImageUrl",
                value: "url_noquis");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555501"),
                column: "ImageUrl",
                value: "url_asado");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555502"),
                column: "ImageUrl",
                value: "url_bife_chorizo");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("55555555-5555-5555-5555-555555555503"),
                column: "ImageUrl",
                value: "url_matambre");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666601"),
                column: "ImageUrl",
                value: "url_pizza_muzza");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("66666666-6666-6666-6666-666666666602"),
                column: "ImageUrl",
                value: "url_pizza_especial");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777701"),
                column: "ImageUrl",
                value: "url_lomito");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("77777777-7777-7777-7777-777777777702"),
                column: "ImageUrl",
                value: "url_hamburguesa");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888801"),
                column: "ImageUrl",
                value: "url_gaseosa");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("88888888-8888-8888-8888-888888888802"),
                column: "ImageUrl",
                value: "url_agua");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999901"),
                column: "ImageUrl",
                value: "url_ipa");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("99999999-9999-9999-9999-999999999902"),
                column: "ImageUrl",
                value: "url_honey");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                column: "ImageUrl",
                value: "url_flan");

            migrationBuilder.UpdateData(
                table: "Dish",
                keyColumn: "DishId",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"),
                column: "ImageUrl",
                value: "url_panqueque");
        }
    }
}
