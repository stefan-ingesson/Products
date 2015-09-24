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


        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
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


        //Klarna

        public ViewResult Checkout(Cart cart)
      {
        var cartItems = cart.Lines.Select(item => new List<Dictionary<string, object>>()

        {
          new Dictionary<string, object>
          {
            {"reference", item.Product.ArticleNumber.ToString()},
            {"name", item.Product.Name},
            {"quantity", item.Quantity},
            {"unit_price", (int)item.Product.Price * 100},
            {"tax_rate", 2500}
          }

        });
        var klarnacart = new Dictionary<string, object> { { "items", cartItems } };

        var data = new Dictionary<string, object>
        {
          {"cart", klarnacart}
        };

        return View("CartPartialIndex");
      }
    }
}



