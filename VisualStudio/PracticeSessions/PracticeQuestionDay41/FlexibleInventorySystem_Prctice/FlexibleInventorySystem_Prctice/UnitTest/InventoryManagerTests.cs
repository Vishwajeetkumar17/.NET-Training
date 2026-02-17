using FlexibleInventorySystem_Practice.Models;
using FlexibleInventorySystem_Practice.Services;
using FlexibleInventorySystem_Practice;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlexibleInventorySystem_Prctice.UnitTest
{
    [TestClass]
    public class InventoryManagerTests
    {
        [TestMethod]
        public void AddProduct_ValidProduct_ReturnsTrue()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = SampleData.GetSampleProducts()[2]; // T-Shirt (ClothingProduct)

            // Act
            var result = manager.AddProduct(product);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNotNull(manager.FindProduct(product.Id));
        }

        [TestMethod]
        public void AddProduct_NullProduct_ThrowsException()
        {
            // Arrange
            var manager = new InventoryManager();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => manager.AddProduct(null));
        }

        [TestMethod]
        public void RemoveProduct_ExistingProduct_ReturnsTrue()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = SampleData.GetSampleProducts()[0]; // Laptop (ElectronicProduct)
            manager.AddProduct(product);

            // Act
            var result = manager.RemoveProduct(product.Id);

            // Assert
            Assert.IsTrue(result);
            Assert.IsNull(manager.FindProduct(product.Id));
        }

        [TestMethod]
        public void RemoveProduct_NonExistingProduct_ReturnsFalse()
        {
            // Arrange
            var manager = new InventoryManager();

            // Act
            var result = manager.RemoveProduct("NONEXISTENT");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateQuantity_ExistingProduct_UpdatesQuantity()
        {
            // Arrange
            var manager = new InventoryManager();
            var product = SampleData.GetSampleProducts()[1]; // Milk (GroceryProduct)
            manager.AddProduct(product);

            // Act
            var result = manager.UpdateQuantity(product.Id, 25);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(25, manager.FindProduct(product.Id)?.Quantity);
        }

        [TestMethod]
        public void UpdateQuantity_NonExistingProduct_ReturnsFalse()
        {
            // Arrange
            var manager = new InventoryManager();

            // Act
            var result = manager.UpdateQuantity("NONEXISTENT", 10);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
