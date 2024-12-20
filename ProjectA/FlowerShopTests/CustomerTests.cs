using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CreateOrder_ShouldReturnOrder()
        {
            // Arrange
            var customer = new Customer();
            var flower = new Flower();

            // Act
            var order = customer.CreateOrder(flower);

            // Assert
            Assert.Fail("Method not implemented.");
        }

        [TestMethod]
        public void CancelOrder_ShouldRemoveOrderFromList()
        {
            // Arrange
            var customer = new Customer();
            var order = new Order();
            customer.Orders.Add(order);

            // Act
            var result = customer.CancelOrder(order);

            // Assert
            Assert.Fail("Method not implemented.");
        }
    }
}
