using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.AreEqual(OrderStatus.Pending, order.Status);
            Assert.IsNull(order.Customer);
            Assert.IsNull(order.Flower);
        }
    }
}
