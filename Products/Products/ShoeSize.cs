using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class ShoeSize : Size
    {
        public ShoeSize(int size)
        {
            this.size = size;
        }
        public int size { get; set; }

        public override string GetAsText()
        {
            return String.Format("{0}", size);
        }
    }
}
