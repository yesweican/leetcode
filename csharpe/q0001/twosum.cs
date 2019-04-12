public class Solution {
    public int[] TwoSum(int[] nums, int target) {
            int n = nums.Count();
            int a, b;

            for (int i = 0; i < n; i++)
            {
                a = nums[i];
                for (int j = i+1; j < n; j++)
                {
                        b = nums[j];
                        if ((a+b) == target)
                            return new int[] { i, j };
                }

            }

            return new int[] { -1 };      
    }
}