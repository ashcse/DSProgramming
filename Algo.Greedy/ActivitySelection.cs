using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Greedy
{
    public class Activity
    {
        public int StartTime { get; set; }
        public int FinishTime { get; set; }

    }





    public class ActivitySelection
    {
        public static void MergeSort(Activity[] arr, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, r, m);
            }
        }

        private static void Merge(Activity[] arr, int l, int r, int m)
        {
            Activity[] temp = new Activity[r - l + 1];
            int i = l;
            int j = m + 1;
            int k = 0;
            while((i<=m) && (j <=r))
            {
                if(arr[i].FinishTime < arr[j].FinishTime)
                {
                    temp[k++] = arr[i++];
                }
                else
                {
                    temp[k++] = arr[j++];
                }
            }

            while(i <= m)
            {
                temp[k++] = arr[i++];
            }

            while(j <= r)
            {
                temp[k++] = arr[j++];
            }

            for (i = 0; i < temp.Length; i++)
            {
                arr[l++] = temp[i];
            }
        }

        public static void FindMaxActivities(int[] startArr, int[] finishArr)
        {
            Activity[] activities = new Activity[startArr.Length];

            for (int index = 0; index < startArr.Length; index++)
            {
                activities[index] = new Activity
                {
                    StartTime = startArr[index],
                    FinishTime = finishArr[index]
                };
            }

             MergeSort(activities, 0, activities.Length-1);

            int i = 0;

            Console.WriteLine(activities[i].StartTime + " " + activities[i].FinishTime);

            for (int j = 1; j < activities.Length; j++)
            {
                if(activities[j].StartTime >= activities[i].FinishTime)
                {
                    Console.WriteLine(activities[j].StartTime + " " + activities[j].FinishTime);
                    i = j;
                }
            }
        }


        public static void FindMaximumTwoActivitiesWithCommonPoint(int[] startArr, int[] finishArr)
        {
            Activity[] activities = new Activity[startArr.Length];

            for (int index = 0; index < startArr.Length; index++)
            {
                activities[index] = new Activity
                {
                    StartTime = startArr[index],
                    FinishTime = finishArr[index]
                };
            }

            MergeSort(activities, 0, activities.Length - 1);

            int i = 0;

            int count = 0;


            Console.WriteLine(activities[i].StartTime + " " + activities[i].FinishTime);
            count++;

            for (int j = 1; j < activities.Length; j++)
            {
                if (activities[j].StartTime > activities[i].FinishTime)
                {
                    Console.WriteLine(activities[j].StartTime + " " + activities[j].FinishTime);

                    i = j;
                }
                else if(activities[j].StartTime == activities[i].FinishTime)
                {
                    count++;
                }               
                    
            }
        }
    }
}
