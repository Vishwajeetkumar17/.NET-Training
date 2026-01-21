namespace _4ArithmaticException
{
    public class Program
    {
        public static string Expression(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                return "Error:InvalidExpression";

            string[] parts = expression.Split(' ');
            if (parts.Length != 3)
                return "Error:InvalidExpression";

            string first = parts[0];
            string op = parts[1];
            string second = parts[2];

            if (op != "+" && op != "-" && op != "*" && op != "/")
                return "Error:UnknownOperator";

            if (!int.TryParse(first, out int a) || !int.TryParse(second, out int b))
                return "Error:InvalidNumber";

            if (op == "/" && b == 0)
                return "Error:DivideByZero";

            int result;

            switch (op)
            {
                case "+":
                    result = a + b;
                    break;

                case "-":
                    result = a - b;
                    break;

                case "*":
                    result = a * b;
                    break;

                case "/":
                    result = a / b;
                    break;

                default:
                    result = 0;
                    break;
            }
            return result.ToString();
        }

        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            string result = Expression(input ?? "");
            Console.WriteLine(result);
        }
    }
}
