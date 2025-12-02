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
                     
        }
    }
}