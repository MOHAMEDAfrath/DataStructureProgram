using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{

    public class PrimeNumberIn2D<T> where T:IComparable
    {
        public Node<T> top = null;
        public Node<T> front = null, rear = null;
        public  int range = 0, index = 0, change = 0;
        public void PrimeChecker(int start, int end)
        {
            T[,] primeNumbers = new T[10, 100];
            T[,] Anagram = new T[10, 100];
            T[,] NotAnagram = new T[10, 100];
            for (int i = start + 1; i <= end; i++)
            {
                if (i > 100)
                {
                    string temp = Convert.ToString(i);
                    char ind = temp[0];
                    range = Convert.ToInt32(ind) - 48;

                }
                if (change != range)
                {
                    index = 0;
                    change = range;
                }
                int flag = 0;
                for (int j = start; j < i; j++)
                {
                    if (i != 0 && i != 1 && j != 0 && j != 1 && (i % 2 == 0 || i % j == 0))
                    {
                        flag = 1;
                        break;
                    }
                }
                if (i != 1 && (flag != 1 || i == 2))
                {
                    primeNumbers[range, index] = (T)Convert.ChangeType(i, typeof(T)); ;
                    index++;
                }
            }
            //Anagram Founder
            change = 0;
            for (int k = 0; k < 10; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    if (primeNumbers[k, l].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        Console.Write(primeNumbers[k, l]+" ");

                        if (primeNumbers[k, l].CompareTo((T)Convert.ChangeType(100, typeof(T))) > 0)
                        {
                            string tempVal = Convert.ToString(primeNumbers[k, l]);
                            char ind = tempVal[0];
                            range = Convert.ToInt32(ind) - 48;

                        }
                        if (change != range)
                        {
                            index = 0;
                            change = range;
                        }
                        char[] temp = primeNumbers[k, l].ToString().ToCharArray();
                        Array.Sort(temp);
                        int secondString = 0;
                        int firstString = Convert.ToInt32(String.Join("", temp));
                        int q;
                        for (q = l + 1; q < 100; q++)
                        {
                            char[] secondtemp = primeNumbers[k, q].ToString().ToCharArray();
                            Array.Sort(secondtemp);
                            secondString = Convert.ToInt32(String.Join("", secondtemp));
                            if (firstString == secondString)
                            {
                                break;
                            }
                        }
                        if (secondString == firstString)
                        {
                            Anagram[range, index] = primeNumbers[k, l];
                            StackOperations(Anagram[range,index]);
                            QueueOperations(Anagram[range, index]);
                            index++;
                            Anagram[range, index] = primeNumbers[k, q];
                            StackOperations(Anagram[range,index]);
                            QueueOperations(Anagram[range, index]);
                            index++;

                        }
                    }
                }
                Console.WriteLine(" ");
            }
            Console.WriteLine(" ");
            
            Console.WriteLine("Anagram Numbers in Range ({0} - {1})", start, end);
            for (int k = 0; k < 10; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    if (Anagram[k, l].CompareTo((T)Convert.ChangeType(0, typeof(T)))>0)
                    {
                        Console.Write(Anagram[k, l]+" ");
                    }

                }
               Console.WriteLine(" ");
            }
            Console.WriteLine("Anagram in Reverse using Stack");
            Console.WriteLine(" ");
            Display(this.top);
            Console.WriteLine(" ");
            Console.WriteLine("Anagram Numbers using Queue");
            Console.WriteLine(" ");
            Display(this.front);
            Console.WriteLine(" ");
            Console.WriteLine(" Not Anagram Numbers in Range {0} - {1}", start, end);
            int check = 0; ;
            for (int k = 0; k < 10; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    check = 0;
                    if (primeNumbers[k, l].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        for (int p = 0; p < 10; p++)
                        {
                            for (int m = 0; m < 100; m++)
                            {

                                if (primeNumbers[k, l].CompareTo(Anagram[p, m])==0)
                                {
                                    check = 1;
                                    break;
                                }
                            }
                            if (check == 1)
                            {
                                break;
                            }
                        }
                        if (check == 0)
                        {
                            NotAnagram[k, l] = primeNumbers[k, l];
                            Console.Write(NotAnagram[k, l]+" ");
                        }

                    }
                }
                Console.WriteLine(" ");
            }

        }
        //Stack operations
        public void StackOperations(T data) {
            
            Node<T> newnode = new Node<T>(data);
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
        public void QueueOperations(T data)
        {
            Node<T> newnode = new Node<T>(data);
            if (this.front == null)
            {
                newnode.next = null;
                this.front = newnode;
                this.rear = newnode;
            }
            else
            {
                this.rear.next = newnode;
                this.rear = newnode;
            }
        }
        public void Display(Node<T> top)
        {
            Node<T> temp = top;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine(" ");
        }
    }
}
