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
            Assert.AreEqual(1, category.Flowers.Count);
            Assert.AreEqual(flower, category.Flowers[0]);
            Assert.AreEqual(category, flower.Category);
        }

        [TestMethod]
        public void RemoveFlower_ShouldRemoveFlowerFromList()
        {
            // Arrange
            var category = new Category();
            var flower = new Flower();
            category.AddFlower(flower);

            // Act
            var result = category.RemoveFlower(flower);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, category.Flowers.Count);
            Assert.IsNull(flower.Category);
        }

        [TestMethod]
        public void RemoveFlower_ShouldReturnFalseIfFlowerNotInList()
        {
            // Arrange
            var category = new Category();
            var flower = new Flower();

            // Act
            var result = category.RemoveFlower(flower);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
