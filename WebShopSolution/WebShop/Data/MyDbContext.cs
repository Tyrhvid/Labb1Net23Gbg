using Microsoft.EntityFrameworkCore;
using WebShop.Models;

namespace WebShop.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}