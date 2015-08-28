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
            Controller c = new Controller(storage);

            do
            {
                c.ShowMenu();
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
