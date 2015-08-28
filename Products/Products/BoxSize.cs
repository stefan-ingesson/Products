using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public class BoxSize : Size
    {
        public BoxSize(int l, int w, int h)
        {
           Initialize(l,w,h);
        }
        public BoxSize(int[] size)
        {
            Initialize(size[0],size[1],size[2]);
        }

        public BoxSize(BoxSize box)
        {
            Initialize(box.L, box.W, box.H);
        }
        private void Initialize(int l,int w, int h)
        {
            if (l < 1 || w < 1 || h < 1)
            {
                throw new ArgumentException();
            }
            length = l;
            width = w;
            height = h;
        }

        private int length;
        private int width;
        private int height;
        
        public int L {
            get { return length; }
                }
        public int W
        {
            get { return width; }
        }
        public int H
        {
            get { return height; }
        }

        
        public override string GetAsText()
        {
            return String.Format("{0}x{1}x{2} mm", L, W, H);
        }
    }       
}
