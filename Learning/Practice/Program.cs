public class SaleTransaction
{
    public string? InvoiceNo;
    public string? CustomerName;
    public string? ItemName;
    public int Quantity;
    public decimal PurchaseAmount;
    public decimal SellingAmount;
    public string? ProfitOrLossStatus;
    public decimal ProfitOrLossAmount;
    public decimal ProfitMarginPercent;
}

public class Program
{
    static SaleTransaction? LastTransaction;
    static bool HasLastTransaction;

    public void CreateUser()
    {
        Console.Write("Enter Invoice No:  ");
        string? invoiceNo = Console.ReadLine();
        if (string.IsNullOrEmpty(invoiceNo))
        {
            Console.WriteLine("Enter Correct Invoice Number.");
            return;
        }
        Console.Write("Enter Customer Name:  ");
        string? customerName = Console.ReadLine();
        if (string.IsNullOrEmpty(customerName))
        {
            Console.WriteLine("Enter Correct Customer Name.");
            return;
        }
        Console.Write("Enter Item Name:  ");
        string? itemName = Console.ReadLine();
        if (string.IsNullOrEmpty(itemName))
        {
            Console.WriteLine("Enter Correct Item Name.");
            return;
        }
        Console.Write("Enter Quantity: ");
        string? _quantity = Console.ReadLine();
        if (!int.TryParse(_quantity, out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Enter Correct Quantity.");
            return;
        }
        Console.Write("Enter Purchase Amount (total):  ");
        string? _pAmount = Console.ReadLine();
        if (!decimal.TryParse(_pAmount, out decimal pAmount) || pAmount <= 0)
        {
            Console.WriteLine("Enter Correct Purchase Amount.");
            return;
        }
        Console.Write("Enter Selling Amount (total): ");
        string? _sAmount = Console.ReadLine();
        if (!decimal.TryParse(_sAmount, out decimal sAmount) || sAmount <= 0)
        {
            Console.WriteLine("Enter Correct Selling Amount.");
            return;
        }

        SaleTransaction st = new SaleTransaction();
        st.InvoiceNo = invoiceNo;
        st.CustomerName = customerName;
        st.ItemName = itemName;
        st.Quantity = quantity;
        st.PurchaseAmount = pAmount;
        st.SellingAmount = sAmount;

        Calculate(st);
        LastTransaction = st;
        HasLastTransaction = true;
        Console.WriteLine("");
        Console.WriteLine("Transaction saved successfully.");
        Print(st);
        Console.WriteLine("------------------------------------------------------");
    }

    public void Calculate(SaleTransaction st)
    {
        if (st.SellingAmount > st.PurchaseAmount)
        {
            st.ProfitOrLossStatus = "PROFIT";
            st.ProfitOrLossAmount = st.SellingAmount - st.PurchaseAmount;
        }
        else if (st.SellingAmount < st.PurchaseAmount)
        {
            st.ProfitOrLossStatus = "LOSS";
            st.ProfitOrLossAmount = st.PurchaseAmount - st.SellingAmount;
        }
        else
        {
            st.ProfitOrLossStatus = "BREAK-EVEN";
            st.ProfitOrLossAmount = 0;
        }
        st.ProfitMarginPercent = (st.ProfitOrLossAmount / st.PurchaseAmount) * 100;
    }

    public void Print(SaleTransaction st)
    {
        Console.WriteLine($"Status: {st.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {st.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit/Loss Margin (%): {st.ProfitMarginPercent}");
    }

    public void ViewLastTransaction()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.\n");
            return;
        }

        Console.WriteLine("------ Last Transaction ------");
        Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
        Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
        Console.WriteLine($"Item: {LastTransaction.ItemName}");
        Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
        Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
        Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
        Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
        Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
        Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
        Console.WriteLine("--------------------------\n");
    }

    public void Recalculate()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.\n");
            return;
        }
        Calculate(LastTransaction);
        Print(LastTransaction);
        Console.WriteLine("------------------------------------------------------");
    }

    static void Main()
    {
        Program p = new Program();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        p.CreateUser();
                        break;
                    case 2:
                        p.ViewLastTransaction();
                        break;
                    case 3:
                        p.Recalculate();
                        break;
                    case 4:
                        flag = false;
                        Console.WriteLine("Thank you. Application closed normally.");
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice");
                        break;
                }
            }
        }
    }
}