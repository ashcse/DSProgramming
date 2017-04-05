using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class LongestCommonSubsequence
    {
        public static int lcs(char[] X, char[] Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;
            if (X[m - 1] == Y[n - 1])
                return 1 + lcs(X, Y, m - 1, n - 1);
            else
                return max(lcs(X, Y, m, n - 1), lcs(X, Y, m - 1, n));
        }

        public static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static void Test()
        {
            char [] X = new char[] { 'A', 'G', 'G', 'T', 'A', 'B' };
            char [] Y = new char[] { 'G', 'X', 'T', 'X', 'A', 'Y', 'B' };

            int m = X.Length;
            int n = Y.Length;

            Console.WriteLine(lcs(X, Y, m, n));           
        }
    }
}
