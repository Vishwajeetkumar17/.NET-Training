using System;

namespace Lecture1
{
    public class SimpleCalculator
    {
        public static void Calculate()
        {
            Console.Write("Enter first number: ");
            string? input1 = Console.ReadLine();
            Console.Write("Enter an operator (+, -, *, /): ");
            string? operatorInput = Console.ReadLine();
            Console.Write("Enter second number: ");
            string? input2 = Console.ReadLine();

            if (double.TryParse(input1, out double num1) && double.TryParse(input2, out double num2))
            {
                double result;

                switch (operatorInput)
                {
                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"Result: {num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = num1 - num2;
                        Console.WriteLine($"Result: {num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = num1 * num2;
                        Console.WriteLine($"Result: {num1} * {num2} = {result}");
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                            Console.WriteLine($"Result: {num1} / {num2} = {result}");
                        }
                        else
                        {
                            Console.WriteLine("Error: Division by zero is not allowed.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter valid numbers.");
            }
        }
    }
}