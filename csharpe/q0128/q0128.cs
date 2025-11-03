public class Solution {
    HashSet<int> hash; 
    
    Dictionary<int, int> dict;

    ///////
    /// Time-Limit Exceeded
    /// 
    public int LongestConsecutive(int[] nums) {
        hash = new HashSet<int>();
        dict = new Dictionary<int, int>();
        

        int maxrunning = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (!hash.Contains(nums[i]))
            {
                hash.Add(nums[i]);
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
                
            if(!dict.Keys.Contains(n))
            {
                int run = 0;                    
                if(dict.Keys.Contains(n+1))
                {
                    run = dict[n+1]+1;
                }
                else
                {
                    while (hash.Contains(n))
                    {
                        run++;
                        n++;
                    }
                        
                }
                    
                dict.Add(nums[i], run);
                    
                if (run > maxrunning)
                    maxrunning = run;  
               
            }


        }

        return maxrunning;        
    }
}