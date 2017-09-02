using System;

namespace DynamicProgramming
{
    public class LongestIncreasingSubsequence
    {
        static int maxLis = 1;

        public static int LIS(int [] arr, int n)
        {
            if (n == 1)
                return n;
             int current_lis = 1;

            for(int i =0; i<n-1; i++)
            {
                int subproblemLis = LIS(arr, i);

                if ((arr[i] < arr[n - 1]) && (current_lis < (subproblemLis + 1)))
                {
                    current_lis = 1 + subproblemLis;
                }
            }
                
            if (maxLis < current_lis)
                maxLis = current_lis;

            return current_lis;

           // return current_lis;
        }

        public static void MaxLIS(int[] arr)
        {
            maxLis = 1;
            LIS(arr, arr.Length);

            Console.WriteLine(maxLis);
        }

        public static void Test()
        {
            int[] arr = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };
            MaxLIS(arr);
            Console.ReadLine();
        }
    }

    public class LISUsingArray
    {
        private static int maxLis = 1;
        public static int RecursiveLIS(int [] arr, int n)
        {
            if (n == 0)
                return 1;

            int curr_lis = 1;
            for(int i =0; i<= n; i++)
            {
                int lis = RecursiveLIS(arr, i);

                if((curr_lis < (lis + 1)) && (arr[n] > arr[i]))
                {
                    curr_lis = lis + 1;
                } 
            }

            if(curr_lis > maxLis)
            {
                maxLis = curr_lis;
            }

            return curr_lis;
        }

        public static void RecursiveLISMain(int [] arr)
        {
            maxLis = 1;
            RecursiveLIS(arr, arr.Length-1);
            Console.WriteLine(maxLis);
        }

        public static int LIS(int [] arr)
        {
            int[] lis = new int[arr.Length];
            for(int i = 0; i< arr.Length; i++)
            {
                lis[i] = 1;
            }

            int maxLIS = 1;

            for(int i = 1; i< arr.Length; i++)
            {
                for(int j = 0; j< i; j++)
                {
                    if((arr[i] > arr[j]) && (lis[i] < (lis[j]  +1)))
                    {
                        lis[i] = lis[j] + 1;                        
                    }
                }
            }

            maxLIS = lis[0];
            for(int i = 1; i<lis.Length; i++)
            {
                if (lis[i] > maxLIS)
                    maxLIS = lis[i];
            }

            Console.WriteLine(maxLIS);
            Console.ReadLine();

            return maxLIS;
        }

        public static void Test()
        {
            //int[] arr = new int[] { 10, 22, 9, 33, 21, 50, 41, 60 };

            //LIS(arr);


            int[] arr = new int[] { 10, 22, 9 };
            RecursiveLISMain(arr);
        }
    }

}
