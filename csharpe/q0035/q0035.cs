using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //using binary search similar to Q528
    public class q035
    {
        public int SearchInsert(int[] nums, int target)
        {

            int l = nums.Length;
            if (target > nums[l - 1])
                return l;
            if (target < nums[0])
                return 0;


            int left = 0; int right = nums.Length - 1;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (target == nums[mid])
                    return mid;

                if (target < nums[mid])
                    right = mid;
                else
                    left = mid + 1;

            }

            return left;
        }
    }
}
