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
            Assert.Fail("Method not implemented.");
        }

        [TestMethod]
        public void CancelOrder_ShouldSetStatusToCanceled()
        {
            // Arrange
            var order = new Order { Status = OrderStatus.Pending };

            // Act
            order.CancelOrder();

            // Assert
            Assert.Fail("Method not implemented.");
        }
    }
}
