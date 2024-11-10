using Cloud2bPOE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Cloud2bPOE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
