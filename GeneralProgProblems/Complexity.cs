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

        #region Backtracking string permutation

        public static void StringPermutationUsingBacktracking(StringBuilder s)
        {
            Permute(s, 0, s.Length - 1);
        }

        /// <summary>
        /// Time complexity analysis:
        /// Main loop takes O(n) time (fronm l to r)
        /// from inside loop recursive call happens which passes string by reducing its length by one (l+1 to r)
        /// Hence: T(n) = T(n) * T(n-1)
        /// it can be further reduced to T(n) * T(n-1) * T(n-2).....1
        /// Which is factorial n => N!
        /// Printing each string (in terminating condition when l==r ) takes O(n) time because of its length n
        /// hence to total time complexity will be => O(n*n!)
        /// </summary>       
        private static void Permute(StringBuilder s, int l, int r)
        {
            int i;
            if(l == r)
            {
                Console.WriteLine(s);
            }
            else
            {
                for( i = l; i<=r; i++)
                {
                    Swap(ref s, l, i);
                    Permute(s, l + 1, r);
                    Swap(ref s, l, i);  
                }
            }
        }

        private static void Swap(ref StringBuilder s, int l, int i )
        {
            char temp = s[l];
            s[l] = s[i];
            s[i] = temp;
        }

        #endregion

        #region String permutation with second approach

        public static void AllPermutationOfString(string s)
        {
            StringPermutation(s, "");
        }

        private static void StringPermutation(string str, string prefix)
        {
            if(str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for(int i=0; i<str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    StringPermutation(rem, prefix + str[i]);
                }
            }
        }

        #endregion 
    }
}
