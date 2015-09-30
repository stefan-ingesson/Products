using Klarna.Checkout;
using Newtonsoft.Json.Linq;
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

        public ViewResult ThankYou(string klarna_order_id)
        {
            var connector = Connector.Create("Y7mNXnxIdYxXU6c", Connector.TestBaseUri);

            Order order = new Order(connector, klarna_order_id);
      
            order.Fetch();

       
            var gui = order.GetValue("gui") as JObject;
            var snippet = gui["snippet"];
            return View(snippet);
        }

       public ActionResult Checkout(Cart cart)
      {

        var cartItems = new List<Dictionary<string, object>>();

        foreach (Cart.CartLine item in GetCart().Lines)
        {
          cartItems.Add(new Dictionary<string, object>
                {
                    { "reference", item.Product.ArticleNumber.ToString() },
                    { "name", item.Product.Name },
                    { "quantity", item.Quantity },
                    { "unit_price", (int)item.Product.Price * 100},
                    { "tax_rate", 2500 }
                });
        }
        var cart_info = new Dictionary<string, object> { { "items", cartItems } };

        var data = new Dictionary<string, object>
        {
            { "cart", cart_info }
        };
        var merchant = new Dictionary<string, object>
    {
        { "id", "5214" },
        { "back_to_store_uri", "https://localhost:44300/" },
        { "terms_uri", "https://localhost:44300/Cart/Terms" },
        {
            "checkout_uri",
            "https://localhost:44300/Cart/Checkout"
        },
        {
            "confirmation_uri",
            "https://localhost:44300/Cart/ThankYou" +
            "?klarna_order_id={checkout.order.id}"
        },
        {
            "push_uri",
            "https://localhost:44300/Cart/push" +
            "?klarna_order_id={checkout.order.id}"
        }
    };
        data.Add("purchase_country", "SE");
        data.Add("purchase_currency", "SEK");
        data.Add("locale", "sv-se");
        data.Add("merchant", merchant);
        var connector = Connector.Create("Y7mNXnxIdYxXU6c", Connector.TestBaseUri);

        Order order = new Order(connector);
        order.Create(data);
        order.Fetch();

        // Store order id of checkout in session object.
        // session["klarna_order_id"] = order.GetValue("id") as string;
        // Display checkout
        var gui = order.GetValue("gui") as JObject;
        var snippet = gui["snippet"];
        return View(snippet);
      }
    }

         
    }




