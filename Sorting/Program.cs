using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[] { 3, 2, 4, 1, 7, 6 };

            BubbleSort.Sort( ref array);

            array.ToList().ForEach(s => Console.WriteLine(s));
            

            Console.ReadLine();


        }
    }
}
