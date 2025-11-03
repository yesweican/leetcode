public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int  size = 5* 100000;        
        int[] buffer = new int[size+1];
       
        for (int i=0; i<nums.Length; i++)
        {
            if(nums[i]<=0) continue;
            if(nums[i]>size) continue;

            buffer[nums[i]]=1;
        }

        for(int j=1; j<=size; j++)
        {
            if(buffer[j] == 0)
                return j;
        }
        return 500001;
    }
}