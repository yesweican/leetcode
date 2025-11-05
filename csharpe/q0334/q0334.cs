public class Solution {
    public bool IncreasingTriplet(int[] nums) {
        int[] nums2 = new int[nums.Length];
        bool result = false;
        
        if(CountUniqueValues(nums)<=2)
            return false;
        
        for(int i=0; i<(nums.Length-1); i++)
        {
            nums2[i]=-1;
            for(int j=i+1; j<nums.Length; j++)
            {
                if(nums[j]>nums[i])
                {
                    nums2[i] = j;
                    break;
                }
            }
        }
        
        for(int i=0; i<(nums.Length-2); i++)
        {
            int temp = nums2[i];
            if(temp>0)
            {
                for(int j=temp; j<(nums.Length-1); j++)
                {
                        if ((nums[i]<nums[j]) && (nums2[j] > 0))
                        {
                            return true;
                        }
                }                
            }
        }
        
        return false;
    }
    
    private int CountUniqueValues(int[] nums)
    {
        HashSet<int> hset = new HashSet<int>();
        for(int i=0; i<nums.Length; i++)
        {
            if(!hset.Contains(nums[i]))
            {
                hset.Add(nums[i]);
            }
        }
        
        return hset.Count();
    }
}