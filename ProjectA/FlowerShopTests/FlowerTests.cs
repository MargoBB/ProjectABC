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
            var flower = new Flower { Price = 10m };

            // Act
            flower.UpdatePrice(20m);

            // Assert
            Assert.AreEqual(20m, flower.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdatePrice_ShouldThrowExceptionForNegativePrice()
        {
            // Arrange
            var flower = new Flower();

            // Act
            flower.UpdatePrice(-5m);

            // Assert is handled by ExpectedException
        }
    }
}
