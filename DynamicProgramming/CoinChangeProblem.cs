using System;

namespace DynamicProgramming
{
    public class CoinChangeProblem
    {
        public static int Count(int [] S, int m, int n)
        {
            int[] table = new int[n + 1];

            table[0] = 1; // base condition

            for(int i =0; i< m; i++)
            {
                for(int j = S[i]; j<=n; j++)
                {
                    table[j] = table[j] + table[j - S[i]];
                }
            }

            return table[n];
        }

        public static void Test()
        {
            int[] s = new int[] { 1, 2, 3 };
            int n = 5;
            int result = Count(s, 3, 5);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
