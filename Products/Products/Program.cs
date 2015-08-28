using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class Program
    {
        static void Main(string[] args) {
            ProductStorage storage = new ProductStorage();

            do
            {
                //Add a product
                Console.WriteLine("Time to create an object. Please enter the following information.");
                Console.Write("ProductName:");
                string name = Console.ReadLine();
                Console.Write("ProductID:");
                int id = Int32.Parse(Console.ReadLine());
                //...
                Product product = new Product();
                product.ProductName = name;
                product.ProductID = id;
                product.ProductDescription = "Generic product description.";
                //...

                
                storage.AddNewProduct(product);
                Console.WriteLine("Product added.");
                Console.WriteLine("Press Esc to quit. Any other key for more products.");
              
            } while (Console.ReadKey().Key != ConsoleKey.Escape);


            Console.Write("Enter ProductID to remove:");
            int ID = Int32.Parse(Console.ReadLine());
            storage.RemoveProductID(ID);

            var prodlist = storage.ProductsSortedByName();
            foreach (var item in prodlist)
            {
                Console.WriteLine(item.ProductName);
            }

            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
           
        }
    }
}
