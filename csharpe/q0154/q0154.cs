using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q154
    {
        public int FindMin(int[] nums)
        {
            return FindMin2(nums, 0, nums.Length - 1);
        }

        private int FindMin2(int[] nums, int start, int end)
        {
            if (start == end)
                return nums[start];

            if (end == (start + 1))
            {
                return (nums[start] > nums[end] ? nums[end] : nums[start]);
            }

            int mid = start + (end - start) / 2;

            if ((nums[start] < nums[mid]) && (nums[mid] < nums[end]))
                return FindMin2(nums, start, mid);

            //sorted ascending
            if ((nums[start] < nums[mid]) && (nums[end] < nums[mid]))
                return FindMin2(nums, mid, end);

            if ((nums[start] > nums[mid]) && (nums[end] > nums[mid]))
                return FindMin2(nums, start, mid);

            //NO LONGER impossible
            int t1 = FindMin2(nums, start, mid);
            int t2 = FindMin2(nums, mid, end);

            return t1 < t2 ? t1 : t2;
        }
    }
}
