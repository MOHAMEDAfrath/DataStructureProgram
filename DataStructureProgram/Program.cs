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
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Unordered List");
                        UnorderedList unordered = new UnorderedList();
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
                        OrderedList orderedList = new OrderedList();
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
                        BalancingPrentheses balancing = new BalancingPrentheses();
                        balancing.BalancingParenthesesOperations();
                        Console.WriteLine(" ");
                        break;
                    case "4":
                        return;

                }
            }
           
        }
    }
}
