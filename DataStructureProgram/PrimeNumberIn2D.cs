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
            for (int i = start + 1; i.CompareTo(end)<=0; i++)
            {
                if (i > 100)
                {
                    string temp = Convert.ToString(i);
                    char changeindex = temp[0];
                    range = Convert.ToInt32(changeindex) - 48;

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
                    primeNumbers[range,index] = (T)Convert.ChangeType(i,typeof(T));
                    index++;
                }
            }


            for (int k = 0; k < 10; k++)
            {
                for (int l = 0; l < 100; l++)
                {
                    if (primeNumbers[k, l].CompareTo((T)Convert.ChangeType(0, typeof(T))) > 0)
                    {
                        Console.Write(primeNumbers[k, l] + " ");
                    }
                }
                Console.WriteLine(" ");
            }

        }
    }
}
