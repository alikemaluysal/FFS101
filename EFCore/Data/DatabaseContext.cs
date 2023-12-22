using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data;

//SQL veri tabanının uygulamamdaki temsilcisidir
public class DatabaseContext : DbContext
{
    //Veri tabanı tabloları
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public DatabaseContext()
    {

    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=FFS101ETicaret;Integrated Security=True;");
    //}

}
