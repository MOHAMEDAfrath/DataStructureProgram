using System;

namespace DataStructureProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to data structure program");
            while (true)
            {
                Console.WriteLine("Enter 1 for Unordered List");
                Console.WriteLine("Enter 2 for Ordered List");
                Console.WriteLine("Enter 3 for Balancing Parentheses");
                Console.WriteLine("Enter 4 for Bank Cash Counter");
                Console.WriteLine("Enter 5 for Palindrome check using Dequeue");
                Console.WriteLine("Enter 6 for Queue using stacks ");
                Console.WriteLine("Enter 7 for No of BST");
                Console.WriteLine("Enter 8 for Prime Numbers in Range 1-1000");
                Console.WriteLine("Enter 9 for Hashing in Number Slots");
                Console.WriteLine("Enter 10 for Calendar of a month");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Unordered List");
                        UnorderedList<string> unordered = new UnorderedList<string>();
                        unordered.UnOrdered();
                        Console.WriteLine("The contents in the file: ");
                        unordered.Display();
                        Console.WriteLine("Enter the data in the file to search");
                        unordered.Search(Console.ReadLine());
                        Console.WriteLine("After the contents in the file modified: ");
                        unordered.Display();
                        Console.WriteLine(" ");
                        break;
                    case "2":
                        Console.WriteLine("Ordered List");
                        OrderedList<int> orderedList = new OrderedList<int>();
                        orderedList.Ordered();
                        orderedList.Sort();
                        Console.WriteLine("Enter the data in the file to search");
                        orderedList.Search(Console.ReadLine());
                        Console.WriteLine("After the contents in the file modified: ");
                        orderedList.Display();
                        Console.WriteLine(" ");
                        break;
                    case "3":
                        Console.WriteLine("Balancing Parentheses");
                        BalancingPrentheses<string> balancing = new BalancingPrentheses<string>();
                        balancing.BalancingParenthesesOperations();
                        Console.WriteLine(" ");
                        break;
                    case "4":
                        Console.WriteLine("Bank Cash Counters");
                        BankCashCounter<string> bank = new BankCashCounter<string>();
                        bank.CreateQueueWithCustomers("member1");
                        bank.CreateQueueWithCustomers("member2");
                        bank.CreateQueueWithCustomers("member3");
                        Console.WriteLine("Created the Queue with members");
                        bank.Display();
                        break;
                    case "5":
                        Console.WriteLine("Palindrome");
                        PalindromeDeque<string> palindromeDeque = new PalindromeDeque<string>();
                        Console.WriteLine("Enter the string");
                        palindromeDeque.EnqueueString(Console.ReadLine());
                        break;
                    case "6":
                        Console.WriteLine("Queue using stacks");
                        QueueUsingStacks<string> queue = new QueueUsingStacks<string>();
                        Console.WriteLine("Enter the number of data to be inserted");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter 1 for Enqueue");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                queue.Enqueue(number);
                                Console.WriteLine("Enter 2 for Dequeue");
                                switch (Console.ReadLine())
                                {
                                    case "2":
                                        queue.Dequeue(number);
                                        break;
                                }
                                break; 
                        }
                
                        break;
                    case "7":
                        Console.WriteLine("No of BST for given number of Nodes");
                        Console.WriteLine("Enter the number of nodes");
                        Console.WriteLine("The number of possible BST {0}",NoOfBST.CountBST(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "8":
                        Console.WriteLine("Prime Number and anagrams in range 1-1000");
                        PrimeNumberIn2D<int> primeNumberIn2D = new PrimeNumberIn2D<int>();
                        primeNumberIn2D.PrimeChecker(1,1000);
                        break;
                    case "9":
                        Console.WriteLine("Hashing Slots");
                        Hashing<string> hashing = new Hashing<string>(11);
                        hashing.ReadInput();
                        Console.WriteLine(" ");
                        break;
                    case "10":
                        Console.WriteLine("Calendar");
                        Console.WriteLine("Enter Month");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Year");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Calendar calendar = new Calendar(month,year);
                        Console.WriteLine("Enter 1 to display using 2D array");
                        Console.WriteLine("Enter 2 to display using Queue");
                        if (Console.ReadLine() == "1")
                        {
                            calendar.Header();
                            calendar.CalenderFill();
                            calendar.DisplayCalendar();
                        }
                        else
                        {
                            calendar.Header();
                            calendar.CalenderFill();
                            calendar.Display();

                        }
                        
                        break;
                    case "11":
                        return;

                }
            }
           
        }
    }
}
