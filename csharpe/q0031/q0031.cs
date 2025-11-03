public class Solution {
    public void NextPermutation(int[] nums) {
        int l = nums.Length;
        if(l<2) return;
        bool foundSwap = false;
        int latestSwap = -1;
        int latestLast = -1;
        
        for(int last = l-1; last>0; last--)
        {
            Console.WriteLine("Last"+ last.ToString());          
            for(int i=last-1; i>=0; i--)
            {
                if(nums[i]<nums[last])
                {
                    if(latestSwap<i)
                    {
                        latestSwap = i;
                        latestLast = last;
                    }

                    Console.WriteLine("Possible Swap "+i.ToString() + " "+last.ToString());
                    foundSwap=true;
                    break;
                }
            }
        }
        
         Console.WriteLine("Latest Swap "+latestSwap.ToString() + " "+latestLast.ToString());
        
        if(foundSwap==false)
            Array.Sort(nums);
        else
        {
                    int temp = nums[latestSwap];
                    nums[latestSwap]=nums[latestLast];
                    nums[latestLast]=temp;
            //the sub array from indexSwap to L-1
            Array.Sort(nums, latestSwap+1, l-latestSwap-1);
        }
        return;
    }
}