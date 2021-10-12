using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    /// <summary>
    /// Product DB Context with MS SQL Server
    /// </summary>
    public class ProductDbContext : DbContext
    {
        public ProductDbContext( DbContextOptions<ProductDbContext> options) : base(options) {}
        public DbSet<Product> Products { get; set; }
    }
}
