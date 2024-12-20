using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void ApproveOrder_ShouldSetStatusToCompleted()
        {
            // Arrange
            var order = new Order { Status = OrderStatus.Pending };

            // Act
            order.ApproveOrder();

            // Assert
            Assert.AreEqual(OrderStatus.Completed, order.Status);
        }

        [TestMethod]
        public void CancelOrder_ShouldSetStatusToCanceled()
        {
            // Arrange
            var order = new Order { Status = OrderStatus.Pending };

            // Act
            order.CancelOrder();

            // Assert
            Assert.AreEqual(OrderStatus.Canceled, order.Status);
        }
    }
}
