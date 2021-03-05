using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreModels;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions options) : base(options)
        {
        }

        protected StoreDBContext()
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cart> OrderItems { get; set; }
        public DbSet<OrderItem> OrderItmes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
