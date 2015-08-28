using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    class ConsoleView : IView
    {
        private List<Product> list;
        public ConsoleView(List<Product> list)
        {
            this.list = list;
        }
        public void RenderView()
        {
            Console.WriteLine("ConsoleView says hi and renders some items.");
        
            foreach (var item in list)
            {
                if (Console.ReadKey().Key == ConsoleKey.D3)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(item.ProductName);
                }


                else if (Console.ReadKey().Key == ConsoleKey.D4)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine(item.ProductPrice);
                }
               
            }

           
        }
    }
}
