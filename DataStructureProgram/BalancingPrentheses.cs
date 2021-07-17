using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class BalancingPrentheses<T> where T:IComparable
    {
        public void BalancingParenthesesOperations()
        {
            string expressions = "(5+6)∗(7+8)/(4+3)(5+6)∗(7+8)/(4+3)";
            for(int i = 0; i < expressions.Length; i++)
            {
                if(expressions[i] == '(')
                {
                    Push((T)Convert.ChangeType(expressions[i],typeof(T)));
                }
            }
            for(int i = 0; i < expressions.Length; i++)
            {
                if (expressions[i] == ')')
                {
                    if(this.top == null)
                    {
                        Console.WriteLine(expressions+" Not Balanced Parentheses");
                        return;
                    }
                    Pop();
                }
            }
            bool result = checkEmpty();
            if (result)
            {
                Console.WriteLine(expressions+" Balanced Parentheses");
            }
            else
            {
                Console.WriteLine(expressions+" Not Balanced Parentheses");
            }
        }
        Node<T> top = null;
        public void Push(T data)
        {
            Node<T> newnode = new Node<T>(data);
            if (top == null)
            {
                newnode.next = null;
            }
            else
            {
                newnode.next = this.top;
            }
            this.top = newnode;

        }
        public bool checkEmpty()
        {
            if(this.top == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Pop()
        {
            if (this.top == null)
            {
                Console.WriteLine("Empty Stack");
                return;
            }
            this.top = this.top.next;
        }
       
    }
}
