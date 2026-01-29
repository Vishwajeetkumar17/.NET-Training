namespace MyLibrary;

public class Calculator
{
    // Original methods
    public int Add(int a, int b) => a + b;
    
    public double Divide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public string GetGreeting(string name) => $"Hello, {name}!";

    // New methods for additional exception testing
    public string GetGreetingWithValidation(string name)
    {
        if (name == null)
            throw new ArgumentNullException(nameof(name), "Name cannot be null.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        return $"Hello, {name}!";
    }

    public int Factorial(int n)
    {
        if (n < 0)
            throw new ArgumentOutOfRangeException(nameof(n), "Number cannot be negative.");

        int result = 1;
        for (int i = 2; i <= n; i++)
            result *= i;
        return result;
    }

    public double SquareRoot(double number)
    {
        if (number < 0)
            throw new InvalidOperationException("Cannot calculate square root of negative number.");

        return Math.Sqrt(number);
    }

    public int ParseNumber(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException(nameof(input), "Input cannot be null.");

        if (!int.TryParse(input, out int result))
            throw new FormatException($"'{input}' is not a valid number.");

        return result;
    }
}