using Microsoft.EntityFrameworkCore;
using System;


namespace Product.DataAccess
{
    public class ProductDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= DESKTOP-OI4QV48; DataBase= ProductDb; Trusted_Connection=True;");
        }
        public DbSet<Product> Products { get; set; }
    
    }
}
