using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class OrderedList<T> where T:IComparable
    {
        Node<T> head;
        //reads data from file and add to linked list
        public void Ordered()
        {
            string text = File.ReadAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\OrderedList.txt");
            string[] arr = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                InsertAtLast((T)Convert.ChangeType(arr[i],typeof(T)));
            }

        }

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
        //get last node of linked list
        public Node<T> GetLastNode()
        {
            Node<T> temp = this.head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        //sorts the linked list
        public void Sort()
        {
            Node<T> temp = this.head;
            for (; temp != null; temp = temp.next)
            {
                for (Node<T> cur = temp.next; cur != null; cur = cur.next)
                {
                    if (Convert.ToInt32(temp.data)>Convert.ToInt32(cur.data))
                    {
                        T temporary = temp.data;
                        temp.data = cur.data;
                        cur.data = temporary;
                    }
                }

            }

        }
        //inserts the not found element in the sorted list
        public void InsertAtSortedPosition(T key)
        {
            Node<T> newnode = new Node<T>(key);
            if (Convert.ToInt32(this.head.data) > Convert.ToInt32(key))
            {
                newnode.next = this.head;
                this.head = newnode;
                return;
            }
            Node<T> last = GetLastNode();
            if (Convert.ToInt32(last.data) < Convert.ToInt32(key))
            {
                last.next = newnode;
                return;
            }
            Node<T> temp = this.head;
            Node<T> cur = null;
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
        //searches the data if found removes from list else adds the data to list and is updated to file
        public void Search(string key)
        {
            bool found = true;
            Node<T> temp = this.head;
            while (temp != null)
            {
                if (temp.data.CompareTo((T)Convert.ChangeType(key,typeof(T)))== 0)
                {
                    found = false;
                }
                temp = temp.next;
            }
            if (found == false)
            {
                IfFoundRemove((T)Convert.ChangeType(key, typeof(T)));
            }
            else
            {
                InsertAtSortedPosition((T)Convert.ChangeType(key,typeof(T)));
            }

        }
        //iffound removes from list and add to the file
        public void IfFoundRemove(T key)
        {
            Node<T> temp = this.head;
            Node<T> current = null;
            if (temp.data.CompareTo(key) == 0)
            {
                this.head = temp.next;
            }
            else
            {
                while (temp != null)
                {
                    if (temp.data.CompareTo(key) == 0)
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
                result += temp.data + " ";
                temp = temp.next;

            }
            File.WriteAllText(@"C:\Users\afrat\source\repos\DataStructureProgram\DataStructureProgram\OrderedList.txt", result);
            Console.WriteLine(" ");
        }
    }
}
