using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class FlowerTests
    {
        [TestMethod]
        public void UpdatePrice_ShouldChangePrice()
        {
            // Arrange
            var flower = new Flower();

            // Act
            flower.UpdatePrice(20m);

            // Assert
            Assert.Fail("Method not implemented.");
        }
    }
}
