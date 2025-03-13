

class loanrecords
{
    public string borrowername { get; set; }
    public int amountborrowed { get; set; }

    public int interest { get; set; }

    public string lstatus { get; set; }

    public double interestamount { get; set; }

    public void addRecord()
    {
        Console.WriteLine("Enter the borrower name");
        borrowername = Console.ReadLine();
        Console.WriteLine("Enter the amount borrowed");
        amountborrowed = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the interest");
        interest = Convert.ToInt32(Console.ReadLine());

        lstatus = "unpaid";

        interestamount = calculateInterest();

        Console.WriteLine("\nFrom the inputted value :");
        Console.WriteLine($"{borrowername} borrows {amountborrowed} with the interest rate of {interest}.");
        Console.WriteLine($"Which you will gain {interestamount} as interested amount.");
    }
    public double calculateInterest()
    {
        return amountborrowed * interest / 100;
    }
    public void displayRecord()
    {
        Console.WriteLine("\nBorrower Name: " + borrowername);
        Console.WriteLine("Amount Borrowed: " + amountborrowed);
        Console.WriteLine("Interest: " + interest);
        Console.WriteLine("Interest Amount: " + interestamount);
        Console.WriteLine("Loan Status: " + lstatus);
    }
    public void updateRecord()
    {
        Console.WriteLine("Enter the borrower name");
        borrowername = Console.ReadLine();
        Console.WriteLine("Enter the amount borrowed");
        amountborrowed = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the interest");
        interest = Convert.ToInt32(Console.ReadLine());

        lstatus = "unpaid";
        
        interestamount = calculateInterest();
    }
}