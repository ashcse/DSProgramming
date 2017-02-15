using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MergeSort
    {
        public static void Sort(ref int[] array, int l, int r)
        {          
            if(l<r)
            {
                int m = (l + r) / 2;

                Sort(ref array, l, m);
                Sort(ref array, m + 1, r);
                Merge(ref array, l, m, r);
            }            
        }

        public static void Merge(ref int [] array, int l, int m, int r)
        {

        }        
    }
}
