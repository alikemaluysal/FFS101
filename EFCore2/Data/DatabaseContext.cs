using EFCore2.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore2.Data;

//Veri tabanının uygulamadaki karşılığı
public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }


    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=FFS101ECommerce;Integrated Security=True;");
    //}

    public DatabaseContext()
    {

    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categories = new List<Category>()
        {
           new Category(){Id = 1, Name = "Bilgisayar", CratedDate = DateTime.Now},
           new Category(){Id = 2, Name = "Telefon", CratedDate = DateTime.Now},
           new Category(){Id = 3, Name = "Tablet", CratedDate = DateTime.Now}
        };

        List<Product> products = new List<Product>()
        {
            new Product(){Id = 1, Name = "Asus Bilgisayar", CategoryId = 1, Stock = 30, Price = 15000, CratedDate = DateTime.Now},
            new Product(){Id = 2, Name = "Dell Bilgisayar", CategoryId = 1, Stock = 40, Price = 19000, CratedDate = DateTime.Now},
            new Product(){Id = 3, Name = "Iphone 15", CategoryId = 2, Stock = 50, Price = 17000, CratedDate = DateTime.Now},
            new Product(){Id = 4, Name = "Galaxy S20", CategoryId = 2, Stock = 10, Price = 23000, CratedDate = DateTime.Now},
        };

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Product>().HasData(products);

    }

}
