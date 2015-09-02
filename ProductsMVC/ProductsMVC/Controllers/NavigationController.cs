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
         private ProductDb db = new ProductDb();

      

      
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