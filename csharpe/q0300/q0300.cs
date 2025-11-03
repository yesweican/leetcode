public class Solution {
    List<int> dp;
    //int[] data;
    public int LengthOfLIS(int[] nums)
    {
        int n = nums.Length;
        //data = new int[n];
        dp = new List<int>();

        for(int i=0; i<n; i++)
        {
            int index = dp.BinarySearch(nums[i]);

            if (index>=0)
            {
                //data[i] = index;
                continue;
            } else
            {
                index = ~index;
                if (index < dp.Count)
                {
                    dp[index] = nums[i];
                    //data[i] = index;
                }
                else
                {
                    dp.Add(nums[i]);
                    //data[i] = dp.Count;
                }
            }
        }

        return dp.Count;
    }
}