using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void GetDetails_ShouldReturnFormattedString()
        {
            // Arrange
            var employee = new Employee
            {
                FullName = "John Doe",
                Position = "Manager"
            };

            // Act
            var details = employee.GetDetails();

            // Assert
            Assert.AreEqual("Employee: John Doe, Position: Manager", details);
        }

        [TestMethod]
        public void ProcessOrder_ShouldApprovePendingOrder()
        {
            // Arrange
            var employee = new Employee();
            var order = new Order { Status = OrderStatus.Pending };

            // Act
            employee.ProcessOrder(order);

            // Assert
            Assert.AreEqual(OrderStatus.Completed, order.Status);
        }

        [TestMethod]
        public void ProcessOrder_ShouldNotChangeNonPendingOrder()
        {
            // Arrange
            var employee = new Employee();
            var order = new Order { Status = OrderStatus.Canceled };

            // Act
            employee.ProcessOrder(order);

            // Assert
            Assert.AreEqual(OrderStatus.Canceled, order.Status);
        }
    }
}
