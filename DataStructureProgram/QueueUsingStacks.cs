﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class QueueUsingStacks
    {
        Node top = null;
        Node top1 = null;
        public void Enqueue(int number)
        {
            for(int i = 0; i < number; i++)
            {
                Console.WriteLine("Enter data");
                PushStack1(Console.ReadLine());
            }
           
           for (int i = 0; i < number; i++)
            {
                Pop(this.top);

            }
            Display();
            
        }
        public void Dequeue(int number)
        {
              for (int i = 0; i < number; i++)
             {
                 Pop1();

             }

            
        }
            public void PushStack1(string data)
            {
                Node newnode = new Node(data);
                if (this.top == null)
                {
                    newnode.next = null;
                }
                else
                {
                    newnode.next = this.top;
                }
                this.top = newnode;
            }
        public void Pop(Node top)
        {
            if (this.top == null)
            {
                Console.WriteLine("Empty Stack");
                return;
            }
            else
            {
                PushStack2(this.top.data);
            }
            this.top = this.top.next;
        }



        public void PushStack2(string data)
        {
            Node newnode = new Node(data);
            if (this.top1 == null)
            {
                newnode.next = null;
            }
            else
            {
                newnode.next = this.top1;
            }
            this.top1 = newnode;
        }
        public void Pop1()
        {
            if (this.top1 == null)
            {
                Console.WriteLine("Empty Stack");
                return;
            }
            else
            {
                Console.WriteLine("Poped Queue "+ this.top1.data);
            }
            this.top1 = this.top1.next;
        }



        public void Display()
        {
            Node temp = this.top1;
            while (temp != null)
            {
                Console.Write("-->"+temp.data);
                temp = temp.next;
            }
            Console.WriteLine(" ");
        }

    }
}
