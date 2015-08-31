using System;
using System.Data.Entity;

namespace ProductsMVC.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public float Price { get; set; }
        public long ArticleNumber { get; set; }
    }

    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
