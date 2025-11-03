public class Solution {
    public int FindPeakElement(int[] nums) {
        bool b1, b2;
        for(int i=0; i<nums.Length; i++)
        {
            b1=false; b2=false;
            if(i==0)
                b1=true;
            else
                b1=nums[i-1]<nums[i];

            if(i==(nums.Length-1))
                b2=true;
            else
                b2=nums[i]>nums[i+1];

            if(b1 && b2)
                return i;
        }

        return -1;
    }
}