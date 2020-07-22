using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Merging two sorted Arrays
    /// </summary>
    public class q088
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int currentPosToFill = m + n - 1;
            int currentPos1 = m - 1;
            int currentPos2 = n - 1;

            while (currentPos2 >= 0 && currentPos1 >= 0)
            {
                if (nums1[currentPos1] > nums2[currentPos2])
                {
                    nums1[currentPosToFill] = nums1[currentPos1];
                    currentPosToFill--;
                    currentPos1--;
                }
                else
                {
                    nums1[currentPosToFill] = nums2[currentPos2];
                    currentPosToFill--;
                    currentPos2--;
                }
            }

            //if(currentPos2>=0)
            //{
            while (currentPos2 >= 0)
            {
                nums1[currentPos2] = nums2[currentPos2];
                currentPos2--;
            }
            //}

        }
    }
}
