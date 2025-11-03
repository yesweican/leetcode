public class Solution {
    Dictionary<int, int>data;
    int[] uniques;
    List<IList<int>> result;
    /////
    /// Time-limit Exceeded
    /////
    public IList<IList<int>> FourSum(int[] nums, int target) {
        data = new Dictionary<int, int>();
        result = new List<IList<int>>();
        Array.Sort(nums);

        for(int i=0; i<nums.Length; i++)
        {
            if(!data.Keys.Contains(nums[i]))
            {
                data.Add(nums[i], 1);
            }
            else
                data[nums[i]]++;
        }

        uniques = data.Keys.ToArray();

        List<int> temp = new List<int>();

        DFS(0, temp, (long)target);
        return result;
    }
    private void DFS(int pos, List<int> prefix, long target)
    {
        int level=prefix.Count;
        if(level==4)
        {
            if(target==0)
                result.Add(prefix);            
            return;
        }

        if(pos>=uniques.Length)
            return;

        int currentVal = uniques[pos];
        if((target>0 && target<currentVal)|| (target<=0 && currentVal>0))
            return;

        int max=4-level;
        if(data[currentVal]<max)
            max = data[currentVal];

        for(int i=1; i<=max; i++)
        {
            List<int>clone = new List<int>(prefix);
            for(int j=0; j<i; j++)
            {
                clone.Add(currentVal);
            }
            DFS(pos+1, clone, target-i*(long)currentVal);
        }

        DFS(pos+1, prefix, target);
    }
}