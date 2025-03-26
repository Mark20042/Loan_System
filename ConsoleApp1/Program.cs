using System;
using System.Collections.Generic;
using Dapper;

class Program
{
    static void Main()
    {
        string choice;

        do
        {
            choice = Choose();
            if (choice == "1")
            {
                AddNewRecord();
            }
            else if (choice == "2")
            {
                UpdateRecord();
            }
            else if (choice == "3")
            {
                UpdateLoanStatus();
            }
            else if (choice == "4")
            {
                DisplayAllRecords();
            }
            else if (choice == "5")
            {
                DeleteRecord();
            }
        } while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5");

        Console.WriteLine("\n\nInputted operation is not recognized.");
        Console.WriteLine("Exiting the program");
        Console.WriteLine("\n\nProgrammer Mark Joseph Potot");
    }

    static void AddNewRecord()
    {
        Console.WriteLine("Enter the borrower name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the amount borrowed");
        int amount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the interest");
        int interest = Convert.ToInt32(Console.ReadLine());

        var connection = DatabaseConnection.GetDatabaseConnection();

        string query = @"INSERT INTO LoanRecords 
                        (borrowername, amountborrowed, interest, lstatus, interestamount) 
                        VALUES (@name, @amount, @interest, 'unpaid', @amount * @interest / 100);
                        SELECT * FROM LoanRecords WHERE loanid = LAST_INSERT_ID();";

        var newRecord = connection.QuerySingle<LoanRecord>(query, new
        {
            name,
            amount,
            interest
        });

        Console.WriteLine("\nRecord added successfully!");
        Console.WriteLine($"{newRecord.borrowername} borrows {newRecord.amountborrowed} with the interest rate of {newRecord.interest}.");
        Console.WriteLine($"Which you will gain {newRecord.interestamount} as interested amount.");
    }

    static void UpdateRecord()
    {
        DisplayAllRecords();
        Console.WriteLine("Enter the ID of the record to update:");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the new borrower name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the new amount borrowed");
        int amount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the new interest");
        int interest = Convert.ToInt32(Console.ReadLine());

        var connection = DatabaseConnection.GetDatabaseConnection();

        string query = @"UPDATE LoanRecords 
                       SET borrowername = @name, 
                           amountborrowed = @amount, 
                           interest = @interest,
                           interestamount = @amount * @interest / 100
                       WHERE loanid = @id;
                       SELECT * FROM LoanRecords WHERE loanid = @id;";

        var updatedRecord = connection.QuerySingleOrDefault<LoanRecord>(query, new
        {
            id,
            name,
            amount,
            interest
        });

        if (updatedRecord != null)
        {
            Console.WriteLine("\nRecord updated successfully!");
            Console.WriteLine($"Updated to: {updatedRecord.borrowername} borrows {updatedRecord.amountborrowed} with interest rate {updatedRecord.interest}%");
        }
        else
        {
            Console.WriteLine("\nNo record found with that ID.");
        }
    }

    static void UpdateLoanStatus()
    {
        DisplayAllRecords();
        Console.WriteLine("Enter the ID of the record to mark as paid:");
        int id = Convert.ToInt32(Console.ReadLine());

        var connection = DatabaseConnection.GetDatabaseConnection();

        string query = @"UPDATE LoanRecords 
                       SET lstatus = 'paid' 
                       WHERE loanid = @id;
                       SELECT * FROM LoanRecords WHERE loanid = @id;";

        var updatedRecord = connection.QuerySingleOrDefault<LoanRecord>(query, new { id });

        if (updatedRecord != null)
            Console.WriteLine($"\nLoan status for {updatedRecord.borrowername} updated to 'paid'!");
        else
            Console.WriteLine("\nNo record found with that ID.");
    }

    static void DisplayAllRecords()
    {
        var connection = DatabaseConnection.GetDatabaseConnection();

        string query = "SELECT * FROM LoanRecords ORDER BY loanid";
        var records = connection.Query<LoanRecord>(query);

        Console.WriteLine("\nAll Loan Records:");
        Console.WriteLine("--------------------------------------------------");
        foreach (var record in records)
        {
            Console.WriteLine($"Borrower ID: {record.loanid}");
            Console.WriteLine($"Borrower Name: {record.borrowername}");
            Console.WriteLine($"Amount Borrowed: {record.amountborrowed}");
            Console.WriteLine($"Interest Rate: {record.interest}%");
            Console.WriteLine($"Interest Amount: {record.interestamount}");
            Console.WriteLine($"Status: {record.lstatus}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    static void DeleteRecord()
    {
        DisplayAllRecords();
        Console.WriteLine("Enter the ID of the record to delete:");
        int id = Convert.ToInt32(Console.ReadLine());

        var connection = DatabaseConnection.GetDatabaseConnection();

        string query = @"DELETE FROM LoanRecords 
                       WHERE loanid = @id;";

        int rowsAffected = connection.Execute(query, new { id });

        if (rowsAffected > 0)
            Console.WriteLine("\nRecord deleted successfully!");
        else
            Console.WriteLine("\nNo record found with that ID.");
    }

    public static string Choose()
    {
        Console.WriteLine("\n======================================");
        Console.WriteLine("Operations");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("1   : Add new record");
        Console.WriteLine("2   : Update record");
        Console.WriteLine("3   : Mark loan status");
        Console.WriteLine("4   : Display Records");
        Console.WriteLine("5   : Delete Record");
        Console.WriteLine("any : To exit");
        Console.WriteLine("======================================");
        Console.Write("Do you want to do another operation? : ");
        return Console.ReadLine();
    }
}
