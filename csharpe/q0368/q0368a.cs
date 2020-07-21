using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Largest Divisible Set - DP method
    /// </summary>

    public class q368a
    {

        int maxSize;
        int maxSizeIndex;
        Dictionary<int, int> previous;
        List<int> result;
        int[] dp;

        public IList<int> LargestDivisibleSubsetDP(int[] nums)
        {

            result = new List<int>();
            if (nums.Length == 0)
                return result;

            previous = new Dictionary<int, int>();
            Array.Sort(nums);

            maxSize = 0;
            dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = 1;
                previous.Add(nums[i], -1);
            }
            //build the DP[] and the previous relationship
            //relationship could between the nums or the indexes.....
            //using nums would be easier in reconstructing the largest set
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                        //if dp[i] growing - potentially
                        if(dp[i]-dp[j]==1)
                        {
                            //update chain of previous number
                            previous[nums[i]] = nums[j];
                            if(dp[i]>maxSize)
                            {
                                maxSize = dp[i];
                                maxSizeIndex = i;
                            }
                        }
                    }
                }
            }


            int current = nums[maxSizeIndex];
            while(current!=-1)
            {
                result.Add(current);
                current = previous[current];
            }

            return result;
        }
    }
}
