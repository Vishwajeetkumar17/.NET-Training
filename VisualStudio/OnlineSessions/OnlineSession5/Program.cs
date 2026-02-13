using System.Xml.Linq;

namespace OnlineSession5
{
    public class CreditRiskProcessor
    {
        public bool validateCustomerDetails(int age, string employmentType, double monthlyIncome, double dues, int creditScore, int defaults)
        {
            if(age < 21 || age > 65)
            {
                throw new InvalidCreditDataException("Invalid Age");
            }
            if(employmentType != "Salaried" && employmentType != "Self-Employeed")
            {
                throw new InvalidCreditDataException("Invalid employment type");
            }
            if(monthlyIncome < 20000)
            {
                throw new InvalidCreditDataException("Invalid monthly income");
            }
            if(dues < 0)
            {
                throw new InvalidCreditDataException("Invalid credit dues");
            }
            if (creditScore < 300 || creditScore > 900)
            {
                throw new InvalidCreditDataException("Invalid credit score");
            }
            if(defaults < 0)
            {
                throw new InvalidCreditDataException("Invalid default count");
            }
            return true;
        }

        public double calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
        {
            double debtRatio = dues / (monthlyIncome * 12);

            if (creditScore < 600 || defaults >= 3 || debtRatio > 0.4)
            {
                return 50000;
            }

            if (creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            {
                return 300000;
            }

            if ((creditScore >= 600 && creditScore <= 749) || defaults == 1 || defaults == 2)
            {
                return 150000;
            }
            return 150000;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            CreditRiskProcessor creditRiskProcessor = new CreditRiskProcessor();
            try
            {
                Console.Write("Enter customer name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Employment Type: ");
                string eType = Console.ReadLine();

                Console.Write("Enter Monnthly Income: ");
                double monthlyIncome = double.Parse(Console.ReadLine());

                Console.Write("Enter Dues: ");
                double dues = double.Parse(Console.ReadLine());

                Console.Write("Enter Credit Score: ");
                int creditScore = int.Parse(Console.ReadLine());

                Console.Write("Enter Number of Loan Defaults: ");
                int defaults = int.Parse(Console.ReadLine());

                if (creditRiskProcessor.validateCustomerDetails(age, eType, monthlyIncome, dues, creditScore, defaults))
                {
                    double limit = creditRiskProcessor.calculateCreditLimit(monthlyIncome, dues, creditScore, defaults);

                    Console.WriteLine($"Customer Name: {name}");
                    Console.WriteLine($"Approved Credit Limit: {limit}");
                }
            }
            catch(InvalidCreditDataException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
