using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Sort Colors -> Dutch Flag #2
    public class q075a
    {
        public void SortColors(int[] nums)
        {
            int current = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (current != i)
                    {
                        //swap the value if ran into 0
                        int temp = nums[current];
                        nums[current] = 0;
                        nums[i] = temp;
                    }
                    current++;
                }
            }

            int lastzero = current - 1;
            current = nums.Length - 1;
            for (int i = nums.Length - 1; i > lastzero; i--)
            {
                if (nums[i] == 2)
                {
                    if (current != i)
                    {
                        //swap the value if ran into 0
                        int temp = nums[current];
                        nums[current] = 2;
                        nums[i] = temp;
                    }
                    current--;
                }
            }
        }

        //optimized two pointer solution!
        public void SortColors2(int[] nums)
        {
            int current1 = 0; int current2 = nums.Length - 1;

            for (int i = 0; i <= current2; )
            {
                int c = nums[i];

                if (c == 0)
                {
                    if (current1 != i)
                    {
                        //swap the value if ran into 0
                        int temp = nums[current1];
                        nums[current1] = 0;
                        nums[i] = temp;
                    }
                    current1++;
                    i++;
                }

                if (c == 1)
                    i++;

                if (c == 2)
                {
                    //if (current2 != i)
                    //{
                        //swap the value if ran into 0
                        int temp = nums[current2];
                        nums[current2] = 2;
                        nums[i] = temp;
                    //}
                    current2--;
                    //i NOT increased here; nums[i] could be 0,1,2
                }
            }
        }
    }
}
