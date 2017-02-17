using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hash.ZeroSumSubarray();
            //Hash.CountDistinctUsingHash();

            // Hash.countPairsWithgivenSum();

            // Hash.FindSubArrayWithgivenSum();

            HashMap<string, int> myHashTable = new HashMap<string, int>();
            myHashTable.Add("this", 1);
            myHashTable.Add("is", 2);
            myHashTable.Add("My Hash", 3);
            myHashTable.Add("table", 4);
            myHashTable.Add("functionality", 6);

            Console.WriteLine(" value for table" + myHashTable.Get("table"));

            Console.WriteLine(" Value of funcitonality" + myHashTable.Get("functionality"));

            Console.WriteLine("Removed this " + myHashTable.Remove("this"));



            Console.ReadLine();
        }
    }
}
