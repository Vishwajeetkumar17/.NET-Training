    using NUnit.Framework;
using MyLibrary;

namespace MyLibrary.Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calc;

    [SetUp] // This runs before every test method
    public void Setup()
    {
        _calc = new Calculator();
    }

    [Test]
    public void All_Assertion_Examples()
    {
        // 1. Equality Assertions
        Assert.That(_calc.Add(2, 2), Is.EqualTo(4));
        Assert.That(_calc.Add(2, 2), Is.Not.EqualTo(5));

        // 2. String Assertions
        string msg = _calc.GetGreeting("Alice");
        Assert.That(msg, Does.Contain("Alice"));
        Assert.That(msg, Does.StartWith("Hello"));
        Assert.That(msg, Is.Not.Empty);

        // 3. Numeric Ranges & Precision
        Assert.That(_calc.Divide(10, 3), Is.EqualTo(3.33).Within(0.01));
        Assert.That(10, Is.GreaterThan(5));
        Assert.That(10, Is.InRange(1, 100));

        // 4. Boolean & Nulls
        Assert.That(true, Is.True);
        Assert.That(null, Is.Null);

        // 5. Collection Assertions
        var list = new List<int> { 1, 2, 3 };
        Assert.That(list, Has.Exactly(3).Items);
        Assert.That(list, Contains.Item(2));
        Assert.That(list, Is.Unique);

        // 6. Exception Assertions
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
    }

    // 7. Parameterized Tests (Running the same test with different data)
    [TestCase(1, 2, 3)]
    [TestCase(-1, 1, 0)]
    [TestCase(100, 200, 300)]
    public void Add_MultipleInputs_ReturnsExpected(int a, int b, int expected)
    {
        Assert.That(_calc.Add(a, b), Is.EqualTo(expected));
    }

    // ========== 5 NEW EXCEPTION TEST CASES ==========

    // 1. ArgumentNullException Test
    [Test]
    public void GetGreetingWithValidation_NullName_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => _calc.GetGreetingWithValidation(null));
        Assert.That(ex.ParamName, Is.EqualTo("name"));
    }

    // 2. ArgumentException Test
    [Test]
    public void GetGreetingWithValidation_EmptyName_ThrowsArgumentException()
    {
        var ex = Assert.Throws<ArgumentException>(() => _calc.GetGreetingWithValidation("   "));
        Assert.That(ex.ParamName, Is.EqualTo("name"));
    }

    // 3. ArgumentOutOfRangeException Test
    [Test]
    public void Factorial_NegativeNumber_ThrowsArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _calc.Factorial(-5));
        Assert.That(ex.ParamName, Is.EqualTo("n"));
    }

    // 4. InvalidOperationException Test
    [Test]
    public void SquareRoot_NegativeNumber_ThrowsInvalidOperationException()
    {
        var ex = Assert.Throws<InvalidOperationException>(() => _calc.SquareRoot(-4));
        Assert.That(ex.Message, Does.Contain("Cannot calculate square root"));
    }

    // 5. FormatException Test
    [Test]
    public void ParseNumber_InvalidFormat_ThrowsFormatException()
    {
        var ex = Assert.Throws<FormatException>(() => _calc.ParseNumber("abc"));
        Assert.That(ex.Message, Does.Contain("not a valid number"));
    }
}