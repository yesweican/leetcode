using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q283
    {
        public class Solution
        {
            public void MoveZeroes(int[] nums)
            {
                int pos = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        int temp = nums[pos];
                        nums[pos++] = nums[i];
                        nums[i] = temp;
                    }
                }
            }
        }
    }
}
