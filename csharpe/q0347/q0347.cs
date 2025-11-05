public class Solution {
    
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int>map = new Dictionary<int, int>();
        
        for(int i=0; i<nums.Length; i++)
        {
            if(!map.Keys.Contains(nums[i]))
            {
                map.Add(nums[i],1);
            }
            else
            {
                map[nums[i]] += 1;
            }
        }
        
            map =  map.OrderByDescending(x => x.Value).ToDictionary(t=>t.Key, t=>t.Value);

            List<int> result = new List<int>();

            int counter = 0;
            foreach(var v in map)
            {
                result.Add(v.Key);
                counter++;
                if (counter == k)
                    break;
            }

            return result.ToArray();
    }
}