using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class BankCashCounter<T> where T:IComparable
    {
        Node<T> front = null, rear = null;
        int count = 0;bool flag = true;
        //create a queue with customers
        public void CreateQueueWithCustomers(T customers)
        {

            Node<T> newnode = new Node<T>(customers);
            if (this.front == null)
            {
                count++;
                newnode.next = null;
                this.front = newnode;
                this.rear = newnode;
            }
            else
            {
                count++;
                this.rear.next = newnode;
                this.rear = newnode;
            }
            Console.WriteLine("Queued {0} {1}", count,customers);
        }
        //dequeue operation
        public void Dequeue()
        {
            if (this.front == null)
            {
                Console.WriteLine("Empty queue");
                return;
            }
            //BankOperations(this.front.data);
            BankOperations(this.front.data);
             this.front = this.front.next;
        }
        //each member in queue enter the bank counter and get served
        public void BankOperations(T member)
        {
            while(this.front != null) { 
                int amount = 1000;
           // string member = Dequeue();
            Console.WriteLine(member +" entered the cash counter");

                while (flag)
                {
                    Console.WriteLine("Enter 1 for Withdrawal");
                    Console.WriteLine("Enter 2 for Deposit");
                    Console.WriteLine("Enter 3 to exit");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter amount to be withdrawed");
                            int amountWithdraw = Convert.ToInt32(Console.ReadLine());
                            amount -= amountWithdraw;
                            Console.WriteLine("Withdrawed {0} and the current balance is {1}", amountWithdraw, amount);
                            break;
                        case "2":
                            Console.WriteLine("Enter amount to be Deposited");
                            int amountDeposit = Convert.ToInt32(Console.ReadLine());
                            amount += amountDeposit;
                            Console.WriteLine("Deposited {0} and the current balance is {1}", amountDeposit, amount);
                            break;
                        case "3":
                            return;

                    }
                }
                
            }
        }
        public void Display()
        {
            Node<T> temp = this.front;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine(" ");
            for (int i = 0; i < count; i++)
            {
                Dequeue();
            }
            Console.WriteLine("Queue Served");
            
            
        }



    }
}
