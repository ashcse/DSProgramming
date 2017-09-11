using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Greedy
{
    public class MinimnNoOfPlatform
    {
        private static void Sort(int[] arr, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                Sort(arr, l, m);
                Sort(arr, m + 1, r);
                Merge(arr, l, r, m);
            }
        }

        private static  void Merge(int[] arr, int l, int r, int m)
        {
            int i = l;
            int j = m + 1;
            int k = 0;
            int[] temp = new int[r - l + 1];

            while((i <=m)&&(j <= r))
            {
                if(arr[i]< arr[j])
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while(i <=m)
            {
                temp[k++] = arr[i++];
            }

            while(j <=r)
            {
                temp[k++] = arr[j++];
            }

            for (i = 0; i < temp.Length; i++)
            {
                arr[l++] = temp[i];
            }
        }

        public static void FindMinumumNoPlatform(int[] arrival, int[] depart)
        {
            Sort(arrival, 0, arrival.Length - 1);
            Sort(depart, 0, depart.Length - 1);
            int i = 1;
            int j = 0;
            int count = 0;
            count++;

            int maxPlatform = count;
            while ((i < arrival.Length) && (j < depart.Length))
            {
                if(arrival[i]<depart[j])
                {
                    count++;

                    if(maxPlatform < count)
                    {
                        maxPlatform = count;
                    }
                    i++;
                }
                else
                {
                    count--;
                    j++;
                }
            }

            Console.WriteLine(maxPlatform);

        }
    }
}
