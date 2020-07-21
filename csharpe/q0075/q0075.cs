using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q075
    {
        //Sort Colors -> Dutch Flag #1
        public void SortColors(int[] nums)
        {
            int current = 0;
            for(int i=0; i<nums.Length; i++)
            {
                if(nums[i]==0)
                {
                    if(current!=i)
                    {
                        //swap the value if ran into 0
                        int temp = nums[current];
                        nums[current] = 0;
                        nums[i] = temp;
                    }

                    current++;
                }
            }

            current = nums.Length - 1;
            for (int i = nums.Length-1; i >=0; i--)
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

    }
}
