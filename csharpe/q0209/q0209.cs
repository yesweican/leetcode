public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int n = nums.Length;
        long prefix = 0;
        long[] prefixSum = new long[n+1];

        for(int i=0; i<n; i++)
        {
            prefix += nums[i];
            prefixSum[i+1] = prefix;
        }

        if(prefixSum[n]<target)
            return 0;

        int left = 0, right = 0;
        int min = Int32.MaxValue;
        while(left<=right && right<n)
        {
            long temp = prefixSum[right+1] - prefixSum[left];

            if(temp>=target)
            {
                int temp2 = right-left+1;
                if (temp2<min)
                {
                    min = temp2;
                    if(min==1)
                        return 1;  
                }

                
                while(left<=right)
                {
                    left++;                    
                    long temp3 = prefixSum[right+1]-prefixSum[left];
                    if(temp3 >= target)
                    {
                        int temp4 = right - left + 1;
                        if(temp4<min)
                        {
                            min = temp4;
                            if(min == 1)
                                return 1;                             
                        }

                    }
                    else
                    {
                        break;
                    }
                }
            }

            right++;
        }

        return min;

    }
}