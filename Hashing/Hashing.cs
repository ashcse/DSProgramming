using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    public class Hash
    {

        /// <summary>
        /// This function assumes that array contains distinct elements. In case of duplicate element this logic wont work
        /// for example if array is {12, 11, 12} here difference between max and min elements is 2 and index between last and first index is also 2
        /// hence logic wont work because there are duplicate elements.
        /// 
        /// To fix this use Hashtable to store subarray and check if element exists in hashtable. if exists then break from the hash and pick next
        /// i element.
        /// </summary>
        public static void FindLongestSubarraywithContigousElements()
        {
            int[] arr = { 1, 56, 58, 57, 90, 92, 94, 93, 91, 45 };

            int maxLength = 0;

            for(int i =0; i< arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = i;
                int max = arr[i];
                int maxIndex = i;
                for(int j = i+1; j< arr.Length; j++)
                {
                    if(arr[j]>max)
                    {
                        max = arr[j];
                        maxIndex = j;
                    }

                    if(arr[j]<min)
                    {
                        min = arr[j];
                        maxIndex = j;
                    }

                    if((max-min) == (j - i))
                    {
                        int newMaxLength = max - min + 1;
                        
                        if(newMaxLength > maxLength)
                        {
                            maxLength = newMaxLength;
                        }
                    }                  
                }
            }

            Console.WriteLine(" Maxlength =" + maxLength);
        }

        public static void CountDistinctUsingHash()
        {
            int[] arr = { 1, 2, 1, 3, 4, 2, 3 };
            int k = 4;

            Dictionary<int, int> countHash = new Dictionary<int, int>();

            int count = 0;
            for(int i = 0; i<k; i++)
            {

                if(!countHash.ContainsKey(arr[i]))
                {
                    countHash.Add(arr[i], 1);
                    count++;
                }
                else
                {
                    countHash[arr[i]] += 1;
                }
            }

            Console.WriteLine("distinct count of window 0 " + count);

            for (int i = k; i<arr.Length; i++)
            {
                if(countHash[arr[i-k]] == 1)
                {
                    countHash.Remove(arr[i - k]);
                    count--;
                }
                else
                {
                    countHash[arr[i - k]] -= 1;
                }

                if(!countHash.ContainsKey(arr[i]))
                {
                    count++;
                    countHash.Add(arr[i], 1);
                }
                else
                {
                    countHash[arr[i]] += 1;
                }

                Console.WriteLine("distinct count of window" + i + " " + count);
            }
        }


        public static void CountDistinctWithinK()
        {
            int[] arr = { 1, 2, 1, 3, 4, 2, 3 };
            int k = 4;
            int countDistinct = 0;

            for(int i =0; i<=(arr.Length-k); i++)
            {
                countDistinct = 0;
                //Each window traversal
                for(int j = i; j<(k+i); j++)
                {
                    int l;

                    for (l = i; l <= j; l++)
                    {
                        if (arr[j] == arr[l])
                            break;
                    }

                    if(j == l)
                    {
                        countDistinct++;
                    }
                }

                Console.WriteLine( "Count Distinct for " + i + "th window = " + countDistinct);
            }
        }

        /// <summary>
        /// This method finds largest subarray with sum zero
        /// It uses hashtable to acheive it
        /// </summary>
        public static void ZeroSumSubarray()
        {
            int[] arr = new int[] { 15, -2, 2, -8, 1, 7, 10, 23 };
            Dictionary<int, int> sumHash = new Dictionary<int, int>();
           

            int sum = 0;
            int prevIndex = 0;
            int maxLength = 0;

            for(int i =0; i<arr.Length; i++)
            {
                sum += arr[i];

                if (sumHash.ContainsKey(sum))
                {
                    maxLength = maxLength > (i - sumHash[sum]) ? maxLength : (i - sumHash[sum]);
                }
                else
                { // if not existing some then add it
                    sumHash.Add(sum, i);
                }             

            }

            Console.WriteLine(" Maxlength =" + maxLength);
        }


        public static void FindEmployeesUnderEveryEmployees()
        {
            Dictionary<string, string> empMgrs = new Dictionary<string, string>();
            empMgrs.Add("A", "C");
            empMgrs.Add("B", "C");
            empMgrs.Add("C", "F");
            empMgrs.Add("D", "E");
            empMgrs.Add("E", "F");
            empMgrs.Add("F", "F");

            Dictionary<string, List<string>> mgrEmps = new Dictionary<string, List<string>>();

            foreach(KeyValuePair<string, string> empMgrPair in empMgrs)
            {
                if (empMgrPair.Key != empMgrPair.Value)
                {
                    if (!mgrEmps.ContainsKey(empMgrPair.Value))
                    {
                        mgrEmps.Add(empMgrPair.Value, new List<string> { empMgrPair.Key });
                    }
                    else
                    {
                        mgrEmps[empMgrPair.Value].Add(empMgrPair.Key);
                    }

                    if (mgrEmps.ContainsKey(empMgrPair.Key))
                    {
                        foreach (string emp in mgrEmps[empMgrPair.Key])
                        {
                            mgrEmps[empMgrPair.Value].Add(emp);
                        }
                    }
                }
            }     
            
            foreach(KeyValuePair<string, string> pair in empMgrs)
            {

                if (mgrEmps.ContainsKey(pair.Key))
                {
                    Console.WriteLine(mgrEmps[pair.Key].Count);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }        
        }

        public static void FindIntinerary()
        {
            Dictionary<string, string> itinerary = new Dictionary<string, string>();
           // itinerary.Add("")
        }
    }
}
