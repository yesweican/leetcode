public class Solution {
    public int CombinationSum4(int[] nums, int target)
    {
        int[] dp = new int[target+1];

        dp[0] = 1; // why?

        for(int i=1; i<=target; i++) //sum value > 0
        {
            for(int index = 0; index < nums.Length; index++)
            {
                if((i-nums[index])>=0)
                  dp[i] += dp[i - nums[index]]; 
            }
        }

        return dp[target];

    }
}