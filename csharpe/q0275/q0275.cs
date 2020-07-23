using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// H Index - II
    /// </summary>
    public class q275
    {
        public int HIndex(int[] citations)
        {
            int result = 0;
            Array.Sort(citations);
            Array.Reverse(citations);

            int left = 1; int right = citations.Length;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (citations[mid - 1] >= mid)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
