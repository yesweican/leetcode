using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    public class q268
    {
        //not so opimized
        public int MissingNumber(int[] nums)
        {
            int[] newArray = new int[nums.Length + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                newArray[nums[i]] = nums[i] + 1;
            }

            for (int j = 0; j < (nums.Length + 1); j++)
            {
                if (newArray[j] == 0)
                    return j;
            }

            return -1;
        }
    }
}
