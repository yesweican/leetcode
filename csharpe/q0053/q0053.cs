using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q053
    {
        public int MaxSubArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                //nums[i] = Math.Max(nums[i - 1] + nums[i], nums[i]);
                if (nums[i - 1] > 0)
                    nums[i] = nums[i - 1] + nums[i];
            }

            return nums.Max();
        }
    }
}
