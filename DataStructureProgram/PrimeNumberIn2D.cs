using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{

    public class PrimeNumberIn2D<T> where T:IComparable
    {
       
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
                        int SecondString = 0;
                        int firstString = Convert.ToInt32(String.Join("", temp));
                        int q;
                        for (q = l + 1; q < 100; q++)
                        {
                            char[] secondtemp = primeNumbers[k, q].ToString().ToCharArray();
                            Array.Sort(secondtemp);
                            SecondString = Convert.ToInt32(String.Join("", secondtemp));
                            if (firstString == SecondString)
                            {
                                break;
                            }
                        }
                        if (SecondString == firstString)
                        {
                            Anagram[range, index] = primeNumbers[k, l];
                            Push(Anagram[range,index]);
                            index++;
                            Anagram[range, index] = primeNumbers[k, q];
                            Push(Anagram[range,index]);
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
            Display();
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
        public void Display()
        {
            Node<T> temp = this.top;
            while (temp != null)
            {
                Console.Write(temp.data + " ");
                temp = temp.next;
            }
            Console.WriteLine(" ");
        }
    }
}
