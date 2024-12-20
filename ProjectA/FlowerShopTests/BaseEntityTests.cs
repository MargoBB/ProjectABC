using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowerShopDomain;

namespace FlowerShopDomain.Tests
{
    [TestClass]
    public class BaseEntityTests
    {
        [TestMethod]
        public void Id_ShouldHaveDefaultValue()
        {
            // Arrange
            var entity = new MockBaseEntity();

            // Assert
            Assert.AreEqual(0, entity.Id);
        }

        [TestMethod]
        public void Id_ShouldBeSettable()
        {
            // Arrange
            var entity = new MockBaseEntity { Id = 42 };

            // Assert
            Assert.AreEqual(42, entity.Id);
        }

        private class MockBaseEntity : BaseEntity { }
    }
}
