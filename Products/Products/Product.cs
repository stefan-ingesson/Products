namespace Products
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name,int id, string description, float weight, Size size, bool instock = false )
        {
            ProductName = name;
            ProductID = id;
            ProductDescription = description;
            Weight = weight;
            InStock = instock;
            ProductSize = size;
        }
       
        public string ProductName { get; set; }
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public float Weight { get; set; }
        public bool InStock { get; set; }

        public Size ProductSize { get; set; }
    }
}