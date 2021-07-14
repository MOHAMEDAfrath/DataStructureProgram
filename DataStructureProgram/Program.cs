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
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Unordered List");
                        UnorderedList unordered = new UnorderedList();
                        unordered.Unordered();
                        Console.WriteLine("The contents in the file: ");
                        unordered.Display();
                        Console.WriteLine("Enter the data in the file to search");
                        unordered.Search(Console.ReadLine());
                        Console.WriteLine("After the contents in the file modified: ");
                        unordered.Display();
                        break;
                }
            }
           
        }
    }
}
