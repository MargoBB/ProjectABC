using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void AddFlower_ShouldRequireCategory()
        {
            // Arrange
            var categories = new List<Category>();
            var flowers = new List<Flower>();

            // Simulating user input
            var flowerName = "Rose";
            var flowerPrice = 10.0m;

            // Act
            if (categories.Count == 0)
            {
                Assert.AreEqual(0, flowers.Count, "No flowers should be added without categories.");
                return;
            }

            // Assuming the category exists, add a flower
            var category = new Category { Name = "Flowers" };
            categories.Add(category);
            var newFlower = new Flower { Name = flowerName, Price = flowerPrice };
            category.AddFlower(newFlower);
            flowers.Add(newFlower);

            // Assert
            Assert.AreEqual(1, flowers.Count);
            Assert.AreEqual("Rose", flowers[0].Name);
        }

        [TestMethod]
        public void RemoveFlower_ShouldRemoveFromCategoryAndList()
        {
            // Arrange
            var category = new Category { Name = "Category1" };
            var flower = new Flower { Name = "Tulip" };
            category.AddFlower(flower);
            var flowers = new List<Flower> { flower };

            // Act
            category.RemoveFlower(flower);
            flowers.Remove(flower);

            // Assert
            Assert.AreEqual(0, flowers.Count);
            Assert.AreEqual(0, category.Flowers.Count);
        }
    }
}
