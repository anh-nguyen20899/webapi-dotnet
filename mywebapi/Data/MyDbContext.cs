using Microsoft.EntityFrameworkCore;
using mywebapi.Models;

namespace mywebapi.Data;

public class MyDbContext : DbContext
{
    // Initilize Contructor
    public MyDbContext(DbContextOptions options) : base(options)
    {

    }
    /*
    DbSet
    */

    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories {get; set;}

}