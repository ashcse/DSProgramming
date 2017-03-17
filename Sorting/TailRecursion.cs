using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class TailRecursion
    {
        /// <summary>
        /// Simple recursive program for factorial
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Factorial(int n)
        {
            if(n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }

        //Above method can be converted to tail recursive program
        public static  int FactorialUsingTailRecursive(int n)
        {
            return FactTailRecurs(n, 1);
        }

        private static int FactTailRecurs(int n, int a)
        {
            if (n == 0)
                return a;
            return FactTailRecurs(n - 1, n * a);
        }
    }
}
