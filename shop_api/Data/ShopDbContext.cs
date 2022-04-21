using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Data
{
    public class ShopDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
       
        public DbSet<Cart> Carts { get; set; }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p=>p.Category);

            base.OnModelCreating(modelBuilder);
        }
       
    }

}
