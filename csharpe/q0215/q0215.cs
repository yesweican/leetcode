public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        List<int> list=new List<int>();
        for(int i=0; i<nums.Length; i++)
        {
          list.Add(nums[i]);
        }
        
        list.Sort();
        
        return list[nums.Length-k];        
    }
}