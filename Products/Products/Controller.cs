using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class Controller
    {
        private ProductStorage storage;

        public Controller(ProductStorage pstorage)
        {
            storage = pstorage;
        }

        public void ShowMenu()
        {
            Console.WriteLine("THis is the MENU, 1,2,3,4");
            ConsoleKey key = Console.ReadKey().Key;

            if (key == ConsoleKey.D1)
                NewProduct();
            else if (key == ConsoleKey.D2)
                RemoveProduct();
            else if (key == ConsoleKey.D3)
                ListProducts();
            else if (key == ConsoleKey.D4)
                ListProductsByPrice();
         }

        public void NewProduct()
        {
            //Add a product
            Console.WriteLine("Time to create an object. Please enter the following information.");
            Console.Write("ProductName:");
            string name = Console.ReadLine();
            Console.Write("ProductID:");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("ProductPrice:");
            int price = Int32.Parse(Console.ReadLine());
            //...
            Product product = new Product();
            product.ProductName = name;
            product.ProductID = id;
            product.ProductPrice = price;
            product.ProductDescription = "Generic product description.";
            //...
            storage.AddNewProduct(product);
        }

        public void RemoveProduct()
        {
            Console.Write("Enter ProductID to remove:");
            int ID = int.Parse(Console.ReadLine());
            storage.RemoveProductID(ID);
        }

        public void ListProducts()
        {
            var prodlist = storage.ProductsSortedByName();
            IView view = new ConsoleView(prodlist);
            view.RenderView();
        }

        public void ListProductsByPrice()
        {
           var prodByPrice = storage.ProductsSortedByPrice();
           IView view = new ConsoleView(prodByPrice);
           view.RenderView();
        }
    }
}
