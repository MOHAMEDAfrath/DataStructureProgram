using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class PalindromeDeque<T> where T:IComparable
    {
        Node<T> front = null;
        string result = "";
        //Enqueue to Double ended queue
        public void EnqueueString(string data)
        {
            for (int i = 0; i <data.Length; i++) {
                Node<T> newnode = new Node<T>((T)Convert.ChangeType(data[i],typeof(T)));
                if (this.front == null)
                {
                    this.front = newnode;
                }
                else
                {
                    Node<T> lastNode = GetLastNode();
                    lastNode.next = newnode;
                }
            }
            for(int i = 0; i < data.Length; i++)
            {
                //double ended queue allows us to add or delete from both ends
                DeleteLast();
            }
            if(result.Equals(data))
           {
                Console.WriteLine(result+" is a palindrome");
            }
            else
            {
                Console.WriteLine(result+" is not a palindrome");
            }
        }
        //insertion into queue
        public Node<T> GetLastNode()
        {
            Node<T> temp = this.front;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        //delete from last because it is a double ended queue
        public void DeleteLast()
        {
            if (this.front == null)
            {
                return;
            }
            if (this.front.next == null)
            {
                result+=this.front.data;
                return;
            }
            Node<T> newnode = this.front;
            while (newnode.next.next != null)
            {
                newnode = newnode.next;
            }
            result+= newnode.next.data;
            newnode.next = null;
        }
        
        
    }
}
