using EmployeeApp.Core;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

[TestFixture]
public class EmployeeServiceTests
{
    [Test]
    public void GetEmployeeCount_ReturnsCorrectCount()
    {
        var mockRepo = new Mock<IEmployeeRepository>();
        mockRepo.Setup(r => r.GetAll()).Returns(new List<Employee>
        {
            new Employee{Id=1,Name="Ravi"},
            new Employee{Id=2,Name="Anu"}
        });

        var service = new EmployeeService(mockRepo.Object);

        int count = service.GetEmployeeCount();

        Assert.That(count, Is.EqualTo(2));
    }
}