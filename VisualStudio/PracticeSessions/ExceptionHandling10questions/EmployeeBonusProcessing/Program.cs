namespace EmployeeBonusProcessing
{
    class BonusCalculator
    {
        static void Main()
        {
            int[] salaries = { 5000, 0, 7000 };

            // TODO:
            // 1. Loop through salaries
            // 2. Divide bonus by salary
            int bonus = 500;
            foreach (int salary in salaries)
            {
                try
                {
                    int result = bonus / salary;
                    Console.WriteLine($"Salary after Bonus: {salary + bonus}");
                }
                // 3. Handle DivideByZeroException
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Erorr: Salary cannot be Zero");
                }
                // 4. Continue processing remaining employees
            }
        }
    }

}
