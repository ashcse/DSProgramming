using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Greedy
{
    public class Job
    {
        public int Profit { get; set; }
        public int Deadline { get; set; }
        public string Name { get; set; }

    }

    public class JobSeqencingProblem
    {
        private static void Sort(Job[] jobs, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;

                Sort(jobs, l, m);
                Sort(jobs, m + 1, r);
                Merge(jobs, l, r, m); 
            }
        }

        private static void Merge(Job[] jobs, int l, int r, int m)
        {
            int i = l;
            int j = m + 1;
            int k = 0;
            Job[] temp = new Job[r - l + 1];

            while((i <=m)&&(j <=r))
            {
                if(jobs[i].Profit > jobs[j].Profit)
                {
                    temp[k++] = jobs[i++];
                }
                else
                {
                    temp[k++] = jobs[j++];
                }
            }

            while(i <= m)
            {
                temp[k++] = jobs[i++];
            }

            while (j<=r)
            {
                temp[k++] = jobs[j++];
            }

            for (i = 0; i < temp.Length; i++)
            {
                jobs[l++] = temp[i];
            }
        }

        public static void FindJobSequence(Job [] jobs)
        {
            int n = jobs.Length;
            Sort(jobs, 0, n - 1);

            string[] result = new string[n];
            bool[] slots = new bool[n];

            for (int i = 0; i < n; i++)
            {
                slots[i] = false;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = Min(n, jobs[i].Deadline)-1; j >=0 ; j--)
                {
                    if(slots[j] == false)
                    {
                        slots[j] = true;
                        result[j] = jobs[i].Name;
                        break;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                if(slots[i])
                {
                    Console.WriteLine(result[i]);
                }
            }            
        }

        private static int Min(int n, int deadline)
        {
            return (n < deadline) ? n : deadline;
        }
    }
}
