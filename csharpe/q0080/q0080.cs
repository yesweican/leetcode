public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int currentIndex=0;
        int currentVal = nums[0];
        for(int i=1; i<nums.Length; i++)
        {
            bool moreThanOne = false;
            while(i<nums.Length && nums[i]==currentVal)
            {
                moreThanOne=true;
                i++;
            }

            if(moreThanOne)
            {
                currentIndex++;
                nums[currentIndex] = currentVal;
            }

            if(i<nums.Length)
            {
                currentIndex++;
                currentVal=nums[i];
                nums[currentIndex]=currentVal;
            }
        }

        return currentIndex+1;
    }
}