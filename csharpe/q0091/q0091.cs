public class Solution {
    private IList<IList<int>> result = new List<IList<int>>();
    private Dictionary<int, int> dict = new Dictionary<int, int>(); 
    private int arrayLength = -1;
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        arrayLength=nums.Length;
        
        //Need to Sort!!!
        Array.Sort(nums);

        for(int i=0; i<nums.Length; i++)
        {
            if(dict.Keys.Contains(nums[i]))
            {
                dict[nums[i]]++;
            }
            else
            {
                dict[nums[i]] = 1;
            }

        }

        List<int> col = new List<int>();

        result.Add(col);
        Process(col, nums, 0);

        return result;        
        
    }
    
    public void Process(List<int> col, int[] nums, int pos)
    {
        int l = dict[nums[pos]];

        if((pos+l)<arrayLength)
            Process(col, nums, pos + l);

        List<int> temp = new List<int>();
        for(int i=1; i<l+1; i++)
        {
            temp.Add(nums[pos]);
            var newCol = new List<int>(col);
            newCol.AddRange(temp);
            result.Add(newCol);
            if((pos+l)<arrayLength)
                Process(newCol, nums, pos + l);
        }

    }    
}