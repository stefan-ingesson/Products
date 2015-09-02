
using ProductsMVC.Models;
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
   

        //public class Category
        //{
        //    [Key]
        //    public int CategoryId {get; set;}
        //    public string Name { get; set; }
        //    public ICollection<Product> Products { get; set; }
        //}
     
    }
    public class ProductDb : DbContext
        {
            public DbSet<Product> Products { get; set; }
            //public DbSet<Category> Categories { get; set; }
        }
}
