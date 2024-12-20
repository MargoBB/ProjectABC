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
            Assert.IsNotNull(order);
            Assert.AreEqual(customer, order.Customer);
            Assert.AreEqual(flower, order.Flower);
            Assert.AreEqual(OrderStatus.Pending, order.Status);
            Assert.IsTrue(customer.Orders.Contains(order));
            Assert.IsTrue(flower.Orders.Contains(order));
        }

        [TestMethod]
        public void CancelOrder_ShouldRemoveOrderFromList()
        {
            // Arrange
            var customer = new Customer();
            var order = new Order { Customer = customer };
            customer.Orders.Add(order);

            // Act
            var result = customer.CancelOrder(order);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(customer.Orders.Contains(order));
            Assert.AreEqual(OrderStatus.Canceled, order.Status);
        }
    }
}
