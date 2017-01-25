using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    /// <summary>
    /// This class does a sorted merge on two sorted linked lists
    /// </summary>
    public class SortedMerge
    {       
        public static SLLNode DoSortedMerge(SLLNode first, SLLNode second)
        {
            if (first == null) return second;
            if (second == null) return first;

            SLLNode resultList = new SLLNode();

            SLLNode resultTail = resultList; ;

            while ((first != null) && (second != null))
            {
                if(first.Data < second.Data)
                {
                    SLLNode temp = new SLLNode { Data = first.Data };

                    temp.Next = null;

                    first = first.Next;
                    resultTail.Next = temp;                    
                }
                else
                {
                    SLLNode temp = new SLLNode { Data = second.Data };
                    temp.Next = null;

                    second = second.Next;
                    resultTail.Next = temp; 
                }

                resultTail = resultTail.Next;
            }

            if(first != null)
            {
                resultTail.Next = first;
            }

            if(second != null)
            {
                resultTail.Next = second;
            }

            return resultList.Next;
        }
    }
}
