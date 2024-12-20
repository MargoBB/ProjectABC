using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class OrderStatusTests
    {
        [TestMethod]
        public void OrderStatus_ShouldContainExpectedValues()
        {
            // Arrange & Act
            var values = Enum.GetValues(typeof(OrderStatus));

            // Assert
            Assert.AreEqual(3, values.Length);
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Pending));
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Completed));
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Canceled));
        }

        [TestMethod]
        public void OrderStatus_ValuesShouldHaveExpectedIntegerValues()
        {
            // Assert
            Assert.AreEqual(0, (int)OrderStatus.Pending);
            Assert.AreEqual(1, (int)OrderStatus.Completed);
            Assert.AreEqual(2, (int)OrderStatus.Canceled);
        }
    }
}
