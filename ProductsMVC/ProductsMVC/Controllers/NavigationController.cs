using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsMVC.Controllers
{
    public class NavigationController : Controller
    {
         private ProductsMVC.Models.Product.ProductDbContext db = new ProductsMVC.Models.Product.ProductDbContext();

      

      
          public PartialViewResult Menu()
          {
              IEnumerable<string> categories = db.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

              return PartialView(categories);
          }

     
    }
}