using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class OrderedList
    {
        Node head;
        public void Ordered()
        {
            string text = File.ReadAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\OrderedList.txt");
            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
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
        public void Sort()
        {
            Node temp = this.head;
            for (; temp != null; temp = temp.next)
            {
                for (Node cur = temp.next; cur != null; cur = cur.next)
                {
                    if (Convert.ToInt32(temp.data)>Convert.ToInt32(cur.data))
                    {
                        string temporary = temp.data;
                        temp.data = cur.data;
                        cur.data = temporary;
                    }
                }

            }

        }
        public void InsertAtSortedPosition(string key)
        {
            Node newnode = new Node(key);
            if (Convert.ToInt32(this.head.data) > Convert.ToInt32(key))
            {
                newnode.next = this.head;
                this.head = newnode;
                return;
            }
            Node last = GetLastNode();
            if (Convert.ToInt32(last.data) < Convert.ToInt32(key))
            {
                last.next = newnode;
                return;
            }
            Node temp = this.head;
            Node cur = null;
            while (temp != null)
            {
                if(Convert.ToInt32(temp.data) < Convert.ToInt32(key))
                {
                    cur = temp;
                    temp = temp.next; 
                }
                else
                {
                    cur.next = newnode;
                    newnode.next = temp;
                    break;
                }
            }
            
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
            if (found == false)
            {
                IfFoundRemove(key);
            }
            else
            {
                InsertAtSortedPosition(key);
            }

        }
        public void IfFoundRemove(string key)
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
                result += temp.data + " ";
                temp = temp.next;

            }
            File.WriteAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\OrderedList.txt", result);
            Console.WriteLine(" ");
        }
    }
}
