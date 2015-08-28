using Products;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestofBoxSizeIntConstructorPass()
        {
            Size s = new BoxSize(1, 1, 1);
            string text = s.GetAsText();
            Assert.AreEqual("1x1x1 mm", text);
        }

        [TestMethod]
        public void TestofBoxSizeIntArrayConstructorPass()
        {
            Size s = new BoxSize(new int[3]{1,1,1});
            string text = s.GetAsText();
            Assert.AreEqual("1x1x1 mm", text);
        }

        [TestMethod]
        public void TestofBoxSizeObjectConstructorPass()
        {
            BoxSize bs = new BoxSize(1, 1, 1);
            Size s = new BoxSize(bs);
            string text = s.GetAsText();
            Assert.AreEqual("1x1x1 mm", text);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Side length values less than 1 was inappropriately allowed.")]
        public void TestofBoxSizeInvalidValues()
        {
            Size s = new BoxSize(-1,0,-1);
        }

        [TestMethod]
        public void ShoeSizeConstructionPass()
        {
            Size s = new ShoeSize(43);
            string text = s.GetAsText();
            Assert.AreEqual("43", text);
        }

        [TestMethod]
        public void AddProductToProductStoragePass()
        {
            Product p = new Product("Testprodukt", 1, "Testdescription", 1.0f, new BoxSize(1, 1, 1), true);
            ProductStorage ps = new ProductStorage();
            ps.AddNewProduct(p);
            Assert.AreEqual(ps.ProductCount(), 1);
        }

        [TestMethod]
        public void RemoveProductFromProductStoragePass()
        {
            Product p = new Product("Testprodukt", 1, "Testdescription", 1.0f, new BoxSize(1, 1, 1), true);
            ProductStorage ps = new ProductStorage();
            ps.AddNewProduct(p);
            ps.RemoveProductID(1);
            Assert.AreEqual(ps.ProductCount(), 0);
        }

        [TestMethod]
        public void SortProductsByNamePass()
        {
            ProductStorage ps = new ProductStorage();
            Product p1 = new Product("Testprodukt", 1, "Testdescription", 1.0f, new BoxSize(1, 1, 1), true);
            Product p2 = new Product("ABC produkt", 1, "Testdescription", 1.0f, new BoxSize(1, 1, 1), true);
            ps.AddNewProduct(p1);
            ps.AddNewProduct(p2);

            List<Product> sortedlist = ps.ProductsSortedByName();
            Assert.AreEqual(sortedlist[0].ProductName, "ABC produkt");
        }
        [TestMethod]
        public void SortProductsByPricePass()
        {

        }

    }
}
