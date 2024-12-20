using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            Assert.AreEqual(3, values.Length, "OrderStatus should contain 3 values.");
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Pending), "OrderStatus should contain Pending.");
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Completed), "OrderStatus should contain Completed.");
            Assert.IsTrue(values.Cast<OrderStatus>().Contains(OrderStatus.Canceled), "OrderStatus should contain Canceled.");
        }

        [TestMethod]
        public void OrderStatus_ValuesShouldHaveExpectedIntegerValues()
        {
            // Assert
            Assert.AreEqual(0, (int)OrderStatus.Pending, "OrderStatus.Pending should have value 0.");
            Assert.AreEqual(1, (int)OrderStatus.Completed, "OrderStatus.Completed should have value 1.");
            Assert.AreEqual(2, (int)OrderStatus.Canceled, "OrderStatus.Canceled should have value 2.");
        }
    }
}
