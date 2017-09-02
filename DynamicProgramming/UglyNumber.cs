namespace DynamicProgramming
{
    public class UglyNumber
    {
        public static int Divide(int a, int b)
        {
            while(a%b ==0)
            {
                a = a / b;
            }

            return a;
        }

        public static bool IsUgly(int n)
        {
            int no = Divide(n, 2);
            no = Divide(no, 3);
            no = Divide(no, 5);

            if (no == 1)
            {
                return true;
            }

            return false;
        }

        public static int GetnthUglyNumber(int n)
        {
            int index = 0, count = 1;

            while(count <= n)
            {
                index++;
                if (IsUgly(index))
                    count++;               
            }

            return index;  
        }

       
    }

    public class UglyNoWithDynamicProg
    {
        public static int GetNthUglyNo(int n)
        {
            int[] no = new int[n];
            int i2 =0, i3 = 0, i5 = 0;

            int nextMultipleOf2 = 2;
            int nextMultipleOf3 = 3;
            int nextMultipleOf5 = 5;
            int nextUglyNo = 1;
            no[0] = 1;

            for(int i= 1; i<n; i++)
            {
                nextUglyNo = Min(nextMultipleOf2, Min(nextMultipleOf3, nextMultipleOf5));
                no[i] = nextUglyNo;

                if(nextUglyNo == nextMultipleOf2)
                {
                    i2 = i2 + 1;
                    nextMultipleOf2 = no[i2] * 2;
                }

                if(nextUglyNo == nextMultipleOf3)
                {
                    i3 = i3 + 1;
                    nextMultipleOf3 = no[i3] * 3;
                }

                if(nextUglyNo == nextMultipleOf5)
                {
                    i5 = i5 + 1;
                    nextMultipleOf5 = no[i5] * 5;
                }
            }

            return nextUglyNo;            
        }

        private static int Min(int a, int b)
        {
            return (a >= b) ? b : a;
        }
    }
}
