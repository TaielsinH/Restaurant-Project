using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Persistency
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<DeliveryType> DeliveryTypes { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Dish> Dishes { get; set; } = null!;


              protected override void OnModelCreating(ModelBuilder modelBuilder)
              {
                     //deliverytype
                     modelBuilder.Entity<DeliveryType>(builder =>
                         {
                                builder.ToTable("DeliveryType");
                                builder.HasKey(d => d.Id);
                                builder.Property(d => d.Name)
                              .HasColumnType("nvarchar(25)")
                              .IsRequired();

                                builder.HasData(
                                   new DeliveryType{Id = 1, Name = "Delivery"},
                                   new DeliveryType{Id = 2, Name = "Take away"},
                                   new DeliveryType{Id = 3, Name = "Dine in"}
                                );
                         });
                     //category
                     modelBuilder.Entity<Category>(builder =>
                     {
                            builder.ToTable("Category");
                            builder.HasKey(c => c.Id);
                            builder.Property(c => c.Name)
                          .HasColumnType("varchar(25)")
                          .IsRequired();
                            builder.Property(c => c.Description)
                          .HasColumnType("varchar(255)")
                          .IsRequired();

                            builder.HasData(
                                   new Category{Id = 1, Name = "Entradas", Description = "Pequeñas porciones para abrir el apetito antes del plato principal.", Order = 1},
                                   new Category{Id = 2, Name = "Ensaladas", Description = "Opciones frescas y livianas, ideales como acompañamiento o plato principal.", Order = 2},
                                   new Category{Id = 3, Name = "Minutas", Description = "Platos rápidos, y clásicos de bodegón: milanesas, tortillas, revueltos.", Order = 3},
                                   new Category{Id = 4, Name = "Pastas", Description = "Variedad de pastas caseras y salsas tradicionales.", Order = 5},
                                   new Category{Id = 5, Name = "Parrilla", Description = "Cortes de carne asados a la parrilla, servidos con guarniciones.", Order = 4},
                                   new Category{Id = 6, Name = "Pizzas", Description = "Pizzas artesanales con masa ccasera y variedad de ingredientes.",Order = 7},
                                   new Category{Id = 7, Name = "Sandwiches", Description = "Sandwiches y lomitos completos preparados al momento.", Order = 6},
                                   new Category{Id = 8, Name = "Bebidas", Description = "Gaseosas, jugos, aguas y opciones sin alcohol.", Order = 8},
                                   new Category{Id = 9, Name = "Cerveza Artesanal", Description = "Cervezas de producción artesanal, rubias, rojas y negras.", Order = 9},
                                   new Category{Id = 10, Name = "Postres", Description = "Clásicos dulces caseros para cerrar la comida.", Order = 10 }
                            );
                     });
                     //Order Item
                     modelBuilder.Entity<OrderItem>(builder =>
                     {
                            builder.ToTable("OrderItem");
                            builder.HasKey(o => o.OrderItemId);
                            builder.Property(o => o.Notes)
                                   .HasColumnType("varchar(MAX)")
                                   .IsRequired();
                            builder.HasOne(oi => oi.OrderNav)
                                   .WithMany(o => o.OrderItems)
                                   .HasForeignKey(oi => oi.Order)
                                   .OnDelete(DeleteBehavior.Cascade); //allows delete on cascade
                            builder.HasOne(oi => oi.StatusNav)
                                   .WithMany(s => s.OrderItems)
                                   .HasForeignKey(oi => oi.Status)
                                   .OnDelete(DeleteBehavior.Restrict);
                            builder.HasOne(oi => oi.DishNav)
                                   .WithMany(d => d.OrderItems)
                                   .HasForeignKey(oi => oi.Dish);
                     });
                     //Status
                     modelBuilder.Entity<Status>(builder =>
                     {
                            builder.ToTable("Status");
                            builder.HasKey(s => s.Id);
                            builder.Property(s => s.Name)
                          .HasColumnType("varchar(25)")
                          .IsRequired();

                            builder.HasData(
                                   new Status{Id =  1, Name = "Pending"},
                                   new Status{Id = 2, Name = "In progress"},
                                   new Status{Id = 3, Name = "Ready"},
                                   new Status{Id = 4, Name = "Delivery"},
                                   new Status{Id = 5, Name = "Closed"}
                            );
                     });
                     //Order
                     modelBuilder.Entity<Order>(builder =>
                     {
                            builder.ToTable("Order");
                            builder.HasKey(o => o.OrderId);
                            builder.Property(o => o.DeliveryTo)
                                   .HasColumnType("varchar(255)")
                                   .IsRequired();
                            builder.Property(o => o.Notes)
                                   .HasColumnType("varchar(MAX)")
                                   .IsRequired();
                            //deliveryType FK
                            builder.HasOne(o => o.DeliveryTypeNav)
                                   .WithMany(d => d.Orders)
                                   .HasForeignKey(o => o.DeliveryType);

                            //OverallStatus FK
                            builder.HasOne(o => o.OverallStatusNav)
                                   .WithMany(s => s.Orders)
                                   .HasForeignKey(o => o.OverallStatus)
                                   .OnDelete(DeleteBehavior.Restrict);

                            builder.Property(d => d.Price)
                                   .HasPrecision(18, 2);
                     });
                     //dish
                     modelBuilder.Entity<Dish>(builder =>
                     {
                            builder.ToTable("Dish");
                            builder.HasKey(d => d.DishId);
                            builder.Property(d => d.Name)
                                   .HasColumnType("varchar(255)")
                                   .IsRequired();

                            builder.Property(d => d.Description)
                                   .HasColumnType("varchar(MAX)")
                                   .IsRequired();

                            builder.Property(d => d.ImageUrl)
                                   .HasColumnType("varchar(MAX)")
                                   .IsRequired();

                            builder.Property(d => d.Price)
                                   .HasPrecision(18, 2);

                            builder.HasOne(d => d.CategoryNav)
                                   .WithMany(c => c.Dishes)
                                   .HasForeignKey(d => d.Category)
                                   .HasConstraintName("FK_Dish_Category_Category");

                    

                     });
            modelBuilder.Entity<Dish>().HasData(
                // --- CATEGORÍA 1: ENTRADAS ---
                new Dish
                {
                    DishId = Guid.Parse("11111111-1111-1111-1111-111111111101"),
                    Name = "Empanada de Carne Cortada a Cuchillo",
                    Description = "Clásica empanada frita rellena de carne cortada a cuchillo, huevo y cebolla de verdeo.",
                    Price = 1500.00m,
                    Available = true,
                    Category = 1, // Entradas
                    ImageUrl = "https://images.unsplash.com/photo-1619926340139-9a2e2245a64e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8ZW1wYW5hZGElMjBhcmdlbnRpbmF8ZW58MHx8MHx8fDA%3D",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("11111111-1111-1111-1111-111111111102"),
                    Name = "Provoleta Especial",
                    Description = "Queso provolone fundido a la parrilla con orégano, aceite de oliva y rodajas de tomate asado.",
                    Price = 6500.00m,
                    Available = true,
                    Category = 1,
                    ImageUrl = "https://cdn.shopify.com/s/files/1/0097/7892/1572/files/SvRumKBuh_2000x1500__1.jpg?v=1741958041",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("11111111-1111-1111-1111-111111111103"),
                    Name = "Rabas a la Romana",
                    Description = "Anillos de calamar rebozados y fritos, servidos con limón y salsa tártara.",
                    Price = 9000.00m,
                    Available = true,
                    Category = 1,
                    ImageUrl = "https://www.clarin.com/img/2025/03/04/VN1snF0v2_1256x620__2.jpg#1741097857035",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                // --- CATEGORÍA 2: ENSALADAS ---
                new Dish
                {
                    DishId = Guid.Parse("22222222-2222-2222-2222-222222222201"),
                    Name = "Ensalada Caesar con Pollo",
                    Description = "Lechuga fresca, croutons, queso parmesano en hebras, pechuga de pollo grillada y aderezo Caesar.",
                    Price = 7800.00m,
                    Available = true,
                    Category = 2, // Ensaladas
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1700089483464-4f76cc3d360b?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8c2FsYWQlMjBjYWVzYXJ8ZW58MHx8MHx8fDA%3D",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("22222222-2222-2222-2222-222222222202"),
                    Name = "Ensalada de Rúcula y Parmesano",
                    Description = "Hojas de rúcula selvática, tomates secos hidratados y láminas de queso parmesano.",
                    Price = 7200.00m,
                    Available = true,
                    Category = 2,
                    ImageUrl = "https://imag.bonviveur.com/ensalada-de-rucula_1000.webp",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 3: MINUTAS ---
                new Dish
                {
                    DishId = Guid.Parse("33333333-3333-3333-3333-333333333301"),
                    Name = "Milanesa a la Napolitana con Fritas",
                    Description = "Milanesa de ternera cubierta con salsa de tomate, jamón y abundante muzzarella. Acompañada de papas bastón.",
                    Price = 11500.00m,
                    Available = true,
                    Category = 3, // Minutas
                    ImageUrl = "https://www.lanacion.com.ar/resizer/v2/milanesa-a-la-napolitana-con-guarnicion-de-papas-VLWFAANIWBGPFO4CSUHS7RYVVQ.jpg?auth=335fda04cf2733e39d11ca0ba979c1d0a8a55e6cdec15e4d5b00cfd59fbf9ed8&width=880&height=586&quality=70&smart=true",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("33333333-3333-3333-3333-333333333302"),
                    Name = "Tortilla de Papas Española",
                    Description = "Tortilla de papas con cebolla y chorizo colorado. Punto babé.",
                    Price = 8500.00m,
                    Available = true,
                    Category = 3,
                    ImageUrl = "https://www.lanacion.com.ar/resizer/v2/tortilla-de-OGZW2PTYC5G6BESKCCDVFU3SDA.jpg?auth=3fba4327702c5439286db1f399c437a61c2c77afba59e23816800e6ceb27e85f&width=880&height=586&quality=70&smart=true",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("33333333-3333-3333-3333-333333333303"),
                    Name = "Suprema Maryland",
                    Description = "Suprema de pollo con salsa de choclo, banana frita y papas pay.",
                    Price = 12000.00m,
                    Available = true,
                    Category = 3,
                    ImageUrl = "https://www.clarin.com/img/2024/08/09/SQrN6GsGV_1256x620__3.jpg#1742234090144",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 4: PASTAS ---
                new Dish
                {
                    DishId = Guid.Parse("44444444-4444-4444-4444-444444444401"),
                    Name = "Sorrentinos de Jamón y Queso",
                    Description = "Sorrentinos caseros rellenos de jamón cocido y muzzarella con salsa a elección (Fileto, Crema o Mixta).",
                    Price = 9500.00m,
                    Available = true,
                    Category = 4, // Pastas
                    ImageUrl = "https://imag.bonviveur.com/sorrentinos-rellenos-de-jamon-y-queso-con-salsa-marinara_1000.webp",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("44444444-4444-4444-4444-444444444402"),
                    Name = "Ñoquis de Papa Caseros",
                    Description = "Los clásicos del 29. Ñoquis de papa servidos con estofado de carne.",
                    Price = 8900.00m,
                    Available = true,
                    Category = 4,
                    ImageUrl = "https://cocinalocal.cl/wp-content/uploads/2022/11/Noquis-de-papa-italianos.jpeg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 5: PARRILLA ---
                new Dish
                {
                    DishId = Guid.Parse("55555555-5555-5555-5555-555555555501"),
                    Name = "Asado de Tira",
                    Description = "Costillar de ternera cortado transversalmente, asado a fuego lento. Incluye guarnición.",
                    Price = 14500.00m,
                    Available = true,
                    Category = 5, // Parrilla
                    ImageUrl = "https://www.clarin.com/img/2022/03/07/0w2kcAVNO_360x240__1.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("55555555-5555-5555-5555-555555555502"),
                    Name = "Bife de Chorizo (400g)",
                    Description = "Corte ancho y jugoso de bife de chorizo, punto a elección.",
                    Price = 16000.00m,
                    Available = true,
                    Category = 5,
                    ImageUrl = "https://media.elgourmet.com/recetas/cover/bife-_UPgMoHqWDK4R60cwJ8hZVk2izxe71l.png",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("55555555-5555-5555-5555-555555555503"),
                    Name = "Matambre a la Pizza",
                    Description = "Matambre de ternera tierno con salsa de tomate y queso muzzarella, finalizado a la parrilla.",
                    Price = 15500.00m,
                    Available = true,
                    Category = 5,
                    ImageUrl = "https://www.clarin.com/img/2022/11/25/tR-l3EmRl_1256x620__2.jpg#1669400323977",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 6: PIZZAS ---
                new Dish
                {
                    DishId = Guid.Parse("66666666-6666-6666-6666-666666666601"),
                    Name = "Pizza Muzzarella Grande",
                    Description = "Salsa de tomate casera, abundante muzzarella, orégano y aceitunas verdes.",
                    Price = 8000.00m,
                    Available = true,
                    Category = 6, // Pizzas
                    ImageUrl = "https://www.laespanolaaceites.com/wp-content/uploads/2019/06/pizza-con-tomate-albahaca-y-mozzarella-1080x671.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("66666666-6666-6666-6666-666666666602"),
                    Name = "Pizza Especial con Jamón y Morrones",
                    Description = "Muzzarella, jamón cocido natural y tiras de morrones asados.",
                    Price = 9500.00m,
                    Available = true,
                    Category = 6,
                    ImageUrl = "https://www.clarin.com/img/2021/11/16/YcExTBfAe_360x240__1.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 7: SANDWICHES ---
                new Dish
                {
                    DishId = Guid.Parse("77777777-7777-7777-7777-777777777701"),
                    Name = "Lomito Completo",
                    Description = "Lomo de ternera en pan francés con lechuga, tomate, jamón, queso y huevo frito. Sale con papas.",
                    Price = 10500.00m,
                    Available = true,
                    Category = 7, // Sandwiches
                    ImageUrl = "https://www.clarin.com/img/2021/07/26/u-aUfp64d_360x240__1.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("77777777-7777-7777-7777-777777777702"),
                    Name = "Hamburguesa Doble Cheddar",
                    Description = "Doble medallón de carne (240g), doble cheddar, panceta crocante y cebolla caramelizada.",
                    Price = 9800.00m,
                    Available = true,
                    Category = 7,
                    ImageUrl = "https://stordfkenticomedia.blob.core.windows.net/df-us/rms/media/recipemediafiles/recipe%20images%20and%20files/retail/desktop%20(600x600)/2023.nov/2023_retail_double-stack-cheeseburger_600x600.jpg?ext=.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 8: BEBIDAS ---
                new Dish
                {
                    DishId = Guid.Parse("88888888-8888-8888-8888-888888888801"),
                    Name = "Gaseosa Cola 500ml",
                    Description = "Línea Coca-Cola o Pepsi según disponibilidad.",
                    Price = 2500.00m,
                    Available = true,
                    Category = 8, // Bebidas
                    ImageUrl = "https://jumboargentina.vtexassets.com/arquivos/ids/782824-800-600?v=638206689771200000&width=800&height=600&aspect=true",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("88888888-8888-8888-8888-888888888802"),
                    Name = "Agua Mineral sin Gas 500ml",
                    Description = "Villavicencio o Eco de los Andes.",
                    Price = 2200.00m,
                    Available = true,
                    Category = 8,
                    ImageUrl = "https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3040341_f.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 9: CERVEZA ---
                new Dish
                {
                    DishId = Guid.Parse("99999999-9999-9999-9999-999999999901"),
                    Name = "Pinta IPA",
                    Description = "Cerveza Indian Pale Ale, amargor intenso y notas cítricas.",
                    Price = 4500.00m,
                    Available = true,
                    Category = 9, // Cerveza
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/32/Fuller%27s_India_pale_ale.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("99999999-9999-9999-9999-999999999902"),
                    Name = "Pinta Honey",
                    Description = "Cerveza rubia suave con un toque de miel.",
                    Price = 4500.00m,
                    Available = true,
                    Category = 9,
                    ImageUrl = "https://cheverry.com.ar/wp-content/uploads/2020/07/okeoke1-5a2cab20b894ce672315277681133744-1024-1024.png",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },

                // --- CATEGORÍA 10: POSTRES ---
                new Dish
                {
                    DishId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa01"),
                    Name = "Flan Casero Mixto",
                    Description = "Flan de huevo tradicional acompañado de dulce de leche y crema chantilly.",
                    Price = 4200.00m,
                    Available = true,
                    Category = 10, // Postres
                    ImageUrl = "https://www.infobae.com/resizer/v2/AR65PTXNQVEAVLYJPDI4LHMHY4.png?auth=2233aa8ae743a1e4dce47a982f5d0ceb147b2f309d8b0f6cb71e76d639b40f08&smart=true&width=1024&height=512&quality=85",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Dish
                {
                    DishId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa02"),
                    Name = "Panqueque de Dulce de Leche",
                    Description = "Panqueque tibio relleno con abundante dulce de leche repostero.",
                    Price = 4000.00m,
                    Available = true,
                    Category = 10,
                    ImageUrl = "https://www.clarin.com/img/2023/04/20/FH-fEx20c_1256x620__2.jpg",
                    CreateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    UpdateDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
               );
                     
        }
    }
}