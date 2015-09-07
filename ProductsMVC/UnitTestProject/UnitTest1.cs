using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsMVC.Models;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

#region Tests for cart
        [TestMethod]
        public void ProductAddedToCartPass()
        {
            // Arrange - create some test products            
            Product p1 = new Product { ID = 1, Name = "P1" };
            Product p2 = new Product { ID = 2, Name = "P2" };

            // Arrange - create a new cart            
            Cart target = new Cart();

            // Act            
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            ProductsMVC.Models.Cart.CartLine[] results = target.Lines.ToArray();

            // Assert           
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
        }



        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange - create some test products   
            Product p1 = new Product { ID = 1, Name = "P1" };
            Product p2 = new Product { ID = 2, Name = "P2" };

            // Arrange - create a new cart    

            Cart target = new Cart();

            // Act    
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);
            ProductsMVC.Models.Cart.CartLine[] results = target.Lines.OrderBy(c => c.Product.ID).ToArray();

            // Assert    
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }



        [TestMethod]
        public void Can_Remove_Line()
        {
            // Arrange - create some test products   
            Product p1 = new Product { ID = 1, Name = "P1" };
            Product p2 = new Product { ID = 2, Name = "P2" };
            Product p3 = new Product { ID = 3, Name = "P3" };

            // Arrange - create a new cart    

            Cart target = new Cart();

            // Act    
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 5);
            target.AddItem(p2, 1);

            target.RemoveLine(p2);

            // Assert    
            Assert.AreEqual(target.Lines.Where(c => c.Product == p2).Count(), 0);
            Assert.AreEqual(target.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Arrange - create some test products    
            Product p1 = new Product { ID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ID = 2, Name = "P2", Price = 40M };

            // Arrange - create a new cart    
            Cart target = new Cart();

            // Act    
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 3);
            decimal result = target.ComputeTotalValue();

            // Assert   
            Assert.AreEqual(result, 440M);
        }

        [TestMethod] public void Can_Clear_Contents() 
        {    
            // Arrange - create some test products    
            Product p1 = new Product { ID = 1, Name = "P1", Price = 100M };   
            Product p2 = new Product { ID = 2, Name = "P2", Price = 50M };    
            
            // Arrange - create a new cart   
            Cart target = new Cart();    
            
            // Arrange - add some items    
            target.AddItem(p1, 1);    
            target.AddItem(p2, 1);    
            
            // Act - reset the cart    
            target.Clear();   
            
            // Assert   
            Assert.AreEqual(target.Lines.Count(), 0); }

#endregion

    }



}
