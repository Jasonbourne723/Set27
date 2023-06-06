using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Set27.Model;

namespace Set27.Infra
{
    public class MyDbContext : AppDbContext<MyDbContext>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<Goods> goods { get; set; }

        public DbSet<OrderItem> orderItems { get; set; }
    }
}