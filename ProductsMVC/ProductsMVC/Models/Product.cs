
using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ProductsMVC.Models
{
    public class Product
    {



        [Display(Name = "Name", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "NameRequiredError")]     
        public string Name { get; set; }
        public int ID { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "PriceRequiredError")]   
        public decimal Price { get; set; }
        [Display(Name = "ArticleNumber", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "ArticleNumberRequiredError")]  
        public long ArticleNumber { get; set; }
        [Display(Name = "Category", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources),
                  ErrorMessageResourceName = "CategoryRequiredError")]  
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
    //public class ProductDb : DbContext
    //    {
    //        public DbSet<Product> Products { get; set; }

    //        public System.Data.Entity.DbSet<ProductsMVC.Models.CrimeScene> CrimeScenes { get; set; }
    //        //public DbSet<Category> Categories { get; set; }
    //    }

    
}
