using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string choice;

        List<loanrecords> records = new List<loanrecords>();

        loanrecords startRecord = new loanrecords();
        startRecord.addRecord();
        records.Add(startRecord);

        do
        {
            choice = choose();
            if (choice == "1")
            {
                loanrecords newRecord = new loanrecords();
                newRecord.addRecord();
                records.Add(newRecord);
            }
            else if (choice == "2")
            {
                int num = 1;

                foreach (var record in records)
                {
                    Console.WriteLine($"{num} . {record.borrowername}");
                    num++;
                }

                Console.WriteLine("Enter the index of the record to update:");
                int index = Convert.ToInt32(Console.ReadLine());
                index = index - 1;
                
                if (index >= 0 && index < records.Count)
                {
                    records[index].updateRecord();
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else if (choice == "3")
            {
                int num = 1;

                foreach (var record in records)
                {
                    Console.WriteLine($"{num} . {record.borrowername}");
                    num++;
                }

                Console.WriteLine("Enter the index of the record you want to paid:");
                int index = Convert.ToInt32(Console.ReadLine());
                index = index - 1;

                if (index >= 0 && index < records.Count)
                {
                    records[index].lstatus = "paid";
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
            else if (choice == "4")
            {
                foreach (var record in records)
                {
                    record.displayRecord();
                }
            }
            else if (choice == "5")
            {
                int num = 1;

                foreach (var record in records)
                {
                    Console.WriteLine($"{num} . {record.borrowername}");
                    num++;
                }
                Console.WriteLine("Enter the index of the record you delete:");
                int index = Convert.ToInt32(Console.ReadLine());
                index = index - 1;

                if (index >= 0 && index < records.Count)
                {
                    records.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }
            }
        } while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5");

        Console.WriteLine("\n\nInputted operation is not recognized.");
        Console.WriteLine("Exiting the program");
        Console.WriteLine("\n\nProgrammer Mark Joseph Potot");
    }

    public static string choose()
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