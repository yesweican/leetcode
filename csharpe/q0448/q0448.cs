public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        HashSet<int> hashset = new HashSet<int>();
        int n = nums.Length;
        List<int> result = new List<int>();
        
        for(int i=0; i<n; i++)
        {
            int temp = nums[i];
            if(!hashset.Contains(temp))
            {
                hashset.Add(temp);
            }
        }
        
        for(int i=1; i<=n; i++)
        {
            if(!hashset.Contains(i))
            {
                result.Add(i);
            }
        }
        
        return result;
    }
}