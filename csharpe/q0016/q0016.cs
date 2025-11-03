public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
            int miniDistance = Int32.MaxValue;
            int sum=Int32.MinValue;

            for(int i=0; i<nums.Length-2; i++ )
            {
                for(int j=i+1; j<nums.Length-1; j++)
                {
                    //if (j >= (nums.Length - 1)) break;

                    for(int k=j+1; k<nums.Length; k++)
                    {
                        //if (k >= nums.Length) break;
                        int current;
                        int currentSum = nums[i] + nums[j] + nums[k] ;
                        if (currentSum >= target)
                            current = currentSum - target;
                        else
                            current = target - currentSum;

                        if (current < miniDistance)
                        {
                            miniDistance = current;
                            sum = currentSum;
                        }
                    }
                }
            }

            return sum;  
    }
}