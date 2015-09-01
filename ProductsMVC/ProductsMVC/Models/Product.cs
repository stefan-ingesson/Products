using System;
using System.Data.Entity;

namespace ProductsMVC.Models
{
    public class Product
    {

  public class ProductDbContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
        }

        public string Name { get; set; }
        public int ID { get; set; }
        public float Price { get; set; }
        public long ArticleNumber { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType
        {
            get;
            set;
        }

      
    }
}
