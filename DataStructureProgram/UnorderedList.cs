using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class UnorderedList<T>
    {
        Node<T> head;
        //reads data from file to list
        public void UnOrdered()
        {
            string text = File.ReadAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\Temporary.txt");
            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < arr.Length; i++)
            {
                InsertAtLast((T)Convert.ChangeType(arr[i],typeof(T)));
            }

        }
        //insert at last
        public void InsertAtLast(T data)
        {
            Node<T> newnode = new Node<T>(data);
            if (this.head == null)
            {
                this.head = newnode;
            }
            else
            {
                Node<T> lastNode = GetLastNode();
                lastNode.next = newnode;
            }

        }
        //get the last node
        
        public Node<T> GetLastNode()
        {
            Node<T> temp = this.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        //search the string if found remove else add
        public void Search(T key)
        {
            bool found = true;
            Node<T> temp = this.head;
            while (temp != null)
            {
                if (temp.data.Equals(key))
                {
                    found = false;  
                }
                temp = temp.next;
            }
            if(found == false)
            {
                IfFoundRemove((T)Convert.ChangeType(key, typeof(T)));
            }
            else
            {
                InsertAtLast(key);
            }
            
        }
        public void IfFoundRemove(T key)
        {
            Node<T> temp = this.head;
            Node<T> current = null;
            if (temp.data.Equals(key))
            {
                this.head = temp.next;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.data.Equals(key))
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
            Node<T> temp = this.head;
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
