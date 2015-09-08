using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductsMVC.Controllers
{
    public class CartController : BaseController
    {
        private ProductDb db = new ProductDb();

        public ViewResult Index(Cart cart, string returnUrl) 
        { 
         return View(new CartIndexViewModel { ReturnUrl = returnUrl, Cart = cart });         
        }


        public RedirectToRouteResult AddToCart(Cart cart,int productId, string returnUrl)
        {
            Product product = db.Products
            .FirstOrDefault(p => p.ID == productId);
            if (product != null) 
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = db.Products
             .FirstOrDefault(p => p.ID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public PartialViewResult Summary(Cart cart) 
        { return PartialView(cart); }
    }
}
