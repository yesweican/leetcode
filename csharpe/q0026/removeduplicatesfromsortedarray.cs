public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int UniqueCount=0;
        int lastValue=0;
        if(nums.Length==0)
            return 0;
        UniqueCount=1;
        lastValue=nums[0];
        for(int i=1; i<nums.Length; i++)
        {
            if(nums[i]==lastValue)
                continue;
            else
            {
                lastValue=nums[i];
                UniqueCount++;
                nums[UniqueCount-1]=lastValue;
            }
            
        }
        
        return UniqueCount;
    }
}