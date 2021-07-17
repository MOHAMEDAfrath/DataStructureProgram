using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    public class Hashing<T> where T:IComparable
    {
        string result = "";
        public int size;
        public LinkedList<T>[] items;
        public Hashing(int size)
        {
            this.size = size;
            this.items = new LinkedList<T>[size];
        }
        public void ReadInput()
        {
            string fileData = File.ReadAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\HashingTest.txt");
            string[] data = fileData.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < data.Length; i++)
            {
                Add((T)Convert.ChangeType(data[i], typeof(T)));
                
            }
            Display();
            Console.WriteLine("Enter the element to be searched:");
            Search((T)Convert.ChangeType(Console.ReadLine(), typeof(T)));
            Display();
            Console.WriteLine("Enter 1 to add to file");
            if(Console.ReadLine() == "1")
            {
                File.WriteAllText(@"\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\HashingTest.txt", result);
            }
            else
            {
                Console.WriteLine("Not Updated");
            }
        }
        public int GetBucketValue(T key)
        {
            int position = Convert.ToInt32(key) % 11;
            return Math.Abs(position);
        }
        public LinkedList<T> GetLinkedList(int position)
        {
            LinkedList<T> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<T>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        public void Add(T data)
        {
            int position = GetBucketValue(data);
            LinkedList<T> linkedList = GetLinkedList(position);
            linkedList.AddLast(data);
        }
        public void Remove(LinkedList<T> list, T value, bool found)
        {
            if(found == true)
            {
                list.Remove(value);
            }
            else
            {
                Add(value);
            }
        }
        public string Display()
        {

            result = "";
            for (int i = 0; i < size; i++)
            {
                LinkedList<T> linkedList = items[i];
                if (linkedList == null)
                {
                    continue;
                }
                foreach (T value in linkedList)
                {
                    Console.WriteLine("Element at bucket {0} of Hash Table is: {1}", i, value);
                    result = result+" "+value;
                }
                
            }
            Console.WriteLine(result);
            return result;
        }
        public void Search(T value)
        {
            int position = GetBucketValue(value);
            LinkedList<T> linkedList = GetLinkedList(position);
            if (linkedList == null)
            {
                return;
            }
            else
            {
                bool found = false;
                foreach (T i in linkedList)
                {
                    if (i.CompareTo(value) == 0)
                    {
                        found = true;
                        break;
                    }
                    
                }
                 Remove(linkedList,value,found);
            }
        }

    }
}
