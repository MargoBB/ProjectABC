using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void AddFlower_ShouldAddFlowerToList()
        {
            // Arrange
            var category = new Category();
            var flower = new Flower();

            // Act
            category.AddFlower(flower);

            // Assert
            Assert.Fail("Method not implemented.");
        }

        [TestMethod]
        public void RemoveFlower_ShouldRemoveFlowerFromList()
        {
            // Arrange
            var category = new Category();
            var flower = new Flower();
            category.Flowers.Add(flower);

            // Act
            var result = category.RemoveFlower(flower);

            // Assert
            Assert.Fail("Method not implemented.");
        }
    }
}
