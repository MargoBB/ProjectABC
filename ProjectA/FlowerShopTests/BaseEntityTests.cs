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

        private class MockBaseEntity : BaseEntity { }
    }
}
