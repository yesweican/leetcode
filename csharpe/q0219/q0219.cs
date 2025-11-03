public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, int> dict = new Dictionary<int,int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!dict.ContainsKey(nums[i]))
                dict.Add(nums[i], i);
            else
            {
                if ((i - dict[nums[i]]) <= k)
                    return true;
                else
                    dict[nums[i]] = i;
            }
        }

        return false;        
    }
}