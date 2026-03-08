using EmployeeApp.Core.Models;
using EmployeeApp.Core.Repositories;
using EmployeeApp.Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EmployeeApp.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepo> _mockRepo;
        private EmployeeServices _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IEmployeeRepo>();
            _service = new EmployeeServices(_mockRepo.Object);
        }

        [Test]
        public void GetEmployeeOrThrow_WithValidId_ReturnsEmployee()
        {
            // Arrange
            var expectedEmployee = new Employee { Id = 1, Name = "Ravi", Email = "ravi@example.com", IsActive = true };
            _mockRepo.Setup(r => r.GetById(1)).Returns(expectedEmployee);

            // Act
            var result = _service.GetEmployeeOrThrow(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("Ravi"));
            _mockRepo.Verify(r => r.GetById(1), Times.Once);
        }

        [Test]
        public void GetEmployeeOrThrow_WithNegativeId_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int invalidId = -1;

            // Act & Assert
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _service.GetEmployeeOrThrow(invalidId));
            Assert.That(ex.ParamName, Is.EqualTo("id"));
            Assert.That(ex.Message, Does.Contain("Id must be positive"));
        }

        [Test]
        public void GetEmployeeOrThrow_WithNonExistentId_ThrowsKeyNotFoundException()
        {
            // Arrange
            int nonExistentId = 999;
            _mockRepo.Setup(r => r.GetById(nonExistentId)).Returns((Employee)null);

            // Act & Assert
            var ex = Assert.Throws<KeyNotFoundException>(() => _service.GetEmployeeOrThrow(nonExistentId));
            Assert.That(ex.Message, Does.Contain($"Employee with {nonExistentId} not found"));
            _mockRepo.Verify(r => r.GetById(nonExistentId), Times.Once);
        }

        [Test]
        public void GetEmployeeOrThrow_WithZeroId_ReturnsEmployee()
        {
            // Arrange
            var expectedEmployee = new Employee { Id = 0, Name = "Test", Email = "test@example.com", IsActive = true };
            _mockRepo.Setup(r => r.GetById(0)).Returns(expectedEmployee);

            // Act
            var result = _service.GetEmployeeOrThrow(0);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(0));
        }
    }

    [TestFixture]
    public class EmployeeRepoTests
    {
        [Test]
        public void Add_WithValidEmployee_SetsEmployeeField()
        {
            // Arrange
            var repo = new EmployeeRepo();
            var employee = new Employee { Id = 10, Name = "Aman", Email = "aman@example.com", IsActive = true };

            // Act
            repo.Add(employee);

            // Assert
            Assert.That(repo.emp, Is.SameAs(employee));
        }

        //[Test]
        //public void Add_WithInvalidEmployeeData_ThrowsArgumentException()
        //{
        //    // Arrange
        //    var repo = new EmployeeRepo();
        //    var invalidEmployee = new Employee { Id = -1, Name = "", Email = "invalid-email", IsActive = true };

        //    // Act & Assert
        //    Assert.Throws<ArgumentException>(() => repo.Add(invalidEmployee));
        //}
    }
}