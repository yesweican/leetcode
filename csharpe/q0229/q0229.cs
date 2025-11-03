public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        int n = (nums.Length + 3) / 3;
        //List<int> result =  new List<int>();
        HashSet<int> hash = new HashSet<int>();

        Dictionary<int, int> dict = new Dictionary<int, int>();

        for(int i=0; i<nums.Length; i++)
        {
            int temp = 0;
            if(!dict.Keys.Contains(nums[i]))
            {
                temp = 1;
                dict.Add(nums[i], 1);

            } else {
                if(!hash.Contains(nums[i]))
                {
                    dict[nums[i]]++;
                    temp = dict[nums[i]];                    
                }
            }
                
            if(temp>=n)
            {
                if(!hash.Contains(nums[i]))
                {
                    //result.Add(nums[i]);
                    hash.Add(nums[i]);
                }
            }
        }

        return (IList<int>)hash.ToList();        
    }


}