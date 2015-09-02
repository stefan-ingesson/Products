using ProductsMVC.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ProductsMVC.Models
{
    public class Product
    {



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

        //public class Category
        //{
        //    [Key]
        //    public int CategoryId {get; set;}
        //    public string Name { get; set; }
        //    public ICollection<Product> Products { get; set; }
        //}
        public class ProductDbContext : DbContext
        {
            public DbSet<Product> Products { get; set; }
            //public DbSet<Category> Categories { get; set; }
        }
    }
}
