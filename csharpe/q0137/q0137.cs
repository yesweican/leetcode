public class Solution {
    public int SingleNumber(int[] nums) {
        Dictionary<int, int>dict = new Dictionary<int, int>();

        for(int i=0; i<nums.Length; i++)
        {
            if(!dict.Keys.Contains(nums[i]))
            {
                dict.Add(nums[i], 1);
            }
            else
            {
                dict[nums[i]]++;
            }
        }

        for(int i=0; i<nums.Length; i++)
        {
            if(dict[nums[i]]==1)
                return nums[i];
        }

        return -1;
    }
}