using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;

namespace CodeFirst
{
    /// <summary>
    /// Context for Shop db.
    /// </summary>
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopDatabase")
        {
        }

        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
