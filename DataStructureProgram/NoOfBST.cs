using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProgram
{
    class NoOfBST
    {
     
        public static double CountBST(int number)
        {
            int[] catalan = new int[number + 1];
            catalan[0] = catalan[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                catalan[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    catalan[i] += catalan[j] * catalan[i - j - 1];
                }
            }
            double power = Math.Pow(10, 8) + 7;
            return Math.Abs(catalan[number]%power);
            

        }
    }
    
}
