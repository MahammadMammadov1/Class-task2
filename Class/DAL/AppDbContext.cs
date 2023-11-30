using Class.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Class.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Colour> Colors { get; set; }    
        public DbSet<Product> Products { get; set; }    
        public DbSet<Catagory> Catagories { get; set; }    
        public DbSet<ProductColor> ProductColors { get; set; }    
        public DbSet<ProductImage> ProductImages { get; set; }    

    }
}
