using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_GetDetails_ShouldBeOverridden()
        {
            // Arrange
            var customer = new Customer { FullName = "Jane Smith" };
            var employee = new Employee { FullName = "John Doe", Position = "Manager" };

            // Act
            var customerDetails = customer.GetDetails();
            var employeeDetails = employee.GetDetails();

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(customerDetails));
            Assert.IsFalse(string.IsNullOrEmpty(employeeDetails));
        }
    }
}
