public class Solution {
    public int MaxProduct(int[] nums) {
        if (nums == null)
            return 0;


        int maxHere = nums[0], minHere=nums[0];
        int maxSoFar = nums[0];

        for(int i=1; i<nums.Length; i++)
        {
            int newMax = maxHere;
            int newMin = minHere;

            maxHere = Math.Max(Math.Max(newMax * nums[i], nums[i]), newMin * nums[i]);
            //this is for keeping track of "minimum(maximum absolute)" negative number
            minHere = Math.Min(Math.Min(newMax * nums[i], nums[i]), newMin * nums[i]);

            maxSoFar = Math.Max(maxHere, maxSoFar);
        }
        return maxSoFar;
    }
}