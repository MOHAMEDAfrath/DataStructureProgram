using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class UnorderedList
    {
        Node head;
        public void Unordered()
        {
            string text = File.ReadAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\Temporary.txt");
            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < arr.Length; i++)
            {
                InsertAtLast(arr[i]);
            }

        }
        public void InsertAtLast(string data)
        {
            Node newnode = new Node(data);
            if (this.head == null)
            {
                this.head = newnode;
            }
            else
            {
                Node lastNode = GetLastNode();
                lastNode.next = newnode;
            }

        }
        
        public Node GetLastNode()
        {
            Node temp = this.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public void Search(string key)
        {
            bool found = true;
            Node temp = this.head;
            while (temp != null)
            {
                if (temp.data == key)
                {
                    found = false;  
                }
                temp = temp.next;
            }
            if(found == false)
            {
                IfFound(key);
            }
            else
            {
                InsertAtLast(key);
            }
            
        }
        public void IfFound(string key)
        {
            Node temp = this.head;
            Node current = null;
            if (temp.data == key)
            {
                this.head = temp.next;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.data == key)
                    {
                        current.next = temp.next;
                        break;
                    }
                    current = temp;
                    temp = temp.next;
                }
            }
        }
        public void Display()
        {
            string result = "";
            Node temp = this.head;
            while (temp != null)
            {
                Console.Write("{0} ", temp.data);
                result += temp.data+" ";
                temp = temp.next;

            }
           File.WriteAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\Temporary.txt", result);
            Console.WriteLine(" ");
        }
    }
}
