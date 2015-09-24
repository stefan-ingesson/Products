using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductsMVC.Models;
using System.Web.UI.WebControls;
using System.IO;
using ProductsMVC.Helpers;
using ProductsMVC.Services;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Http;
using Facebook;
using System.Configuration;

namespace ProductsMVC.Controllers
{
   [RequireHttps]
    public class ProductsController : BaseController
    {

        public int PageSize = 4;

        private ProductDb db = new ProductDb();


        public ViewResult List(string category, string searchString, int page = 1)
        {

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = db.Products
               .Where(p => category == null || p.Category == category || searchString == p.Name)
               .OrderBy(p => p.ID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = db.Products.Count()


                },
                CurrentCategory = category


            };

            return View(model);
        }

        // GET: Products

        public ActionResult Index(string searchProduct)
        {
            var products = from p in db.Products
                           select p;

            if (!String.IsNullOrEmpty(searchProduct))
            {
                products = products.Where(p => p.Name.Contains(searchProduct));
            }
            return View(products);
        }

        //Using remote web api
        private RestService service = new RestService();

        public async Task<ActionResult> Remote()
        {
            Task<List<Product>> task = service.GetProductsAsync();
            return View(await service.GetProductsAsync());
         
        
        }

        public async Task<ActionResult> RemoteId(int id)
        {
            Task<Product> task = service.GetProductByIdAsync(id);
            return View(await service.GetProductByIdAsync(id));
        }

    

        public ViewResult SinglePage()
        {
            return View();
        }


        //public ActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
       [Authorize(Users = "stefan.ingesson@gmail.com")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Authorize(Users = "stefan.ingesson@gmail.com")]
        public ActionResult Create([Bind(Include = "ID,Name,Price,ArticleNumber,Category, ImageUrl")] Product product)
        {

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                TempData["success"] = "Produkt tillagd";
                return RedirectToAction("List");

            }     
            return View(product);
        }





        // GET: Products/Edit/5
        [Authorize(Users = "stefan.ingesson@gmail.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [Authorize(Users = "stefan.ingesson@gmail.com")]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,ArticleNumber,Category, ImageUrl")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize]
        [Authorize(Users = "stefan.ingesson@gmail.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
         [Authorize(Users = "stefan.ingesson@gmail.com")]
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            TempData["success"] = "Produkt borttagen";
            return RedirectToAction("List");
        }


         public ActionResult SetCulture(string culture)
         {
             // Validate input
             culture = CultureHelper.GetImplementedCulture(culture);
             // Save culture in a cookie
             HttpCookie cookie = Request.Cookies["_culture"];
             if (cookie != null)
                 cookie.Value = culture;   // update cookie value
             else
             {
                 cookie = new HttpCookie("_culture");
                 cookie.Value = culture;
                 cookie.Expires = DateTime.Now.AddYears(1);
             }
             Response.Cookies.Add(cookie);
             return RedirectToAction("List");
         }                



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private CrimeSceneREST crime = new CrimeSceneREST();
        public ActionResult CrimeScene()
        {          
            return View("CrimeSceneIndex", crime.GetCrimeScenes());
        }


       //Facebook


   

                  
      

            
        
      


     
       
    }
}
