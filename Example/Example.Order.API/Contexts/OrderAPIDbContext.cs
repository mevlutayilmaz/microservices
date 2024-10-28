using Example.Order.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Order.API.Contexts
{
    public class OrderAPIDbContext : DbContext
    {
        public OrderAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
