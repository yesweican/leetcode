using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q027
    {
        public int RemoveElement(int[] nums, int val)
        {
            int nextPos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ////i>>nextPos, always!
                if (nums[i] != val)
                {
                    nums[nextPos] = nums[i];
                    nextPos++;
                }
            }

            return nextPos;
        }
    }
}
