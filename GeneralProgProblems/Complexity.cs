using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralProgProblems
{
    class Complexity
    {
        /// <summary>
        /// Iterative solution to exponent 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int atoPowb(int a, int b)
        {
            int result = 1;
             while(b> 0)
            {
                result = result * a;
                b--;
            }

            return result;
        }

        public static int A2BDivideAndConquerC(int a, int b)
        {
            if (b  == 1)
                return a;

            if(b%2 == 0)
            {
                return A2BDivideAndConquerC(a*a,  b / 2);
            }
            else
            {
                return a * A2BDivideAndConquerC(a, b - 1);
            }
        }
    }
}
