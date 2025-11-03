public class Solution {
    // int[] array = new int[]{1,2,3,4,5,6,7,8,9};
    IList<IList<int>> result = null;
    public IList<IList<int>> CombinationSum3(int k, int n) {
        result = new List<IList<int>>();
        List<int> startList = new List<int>();
        proceed(startList, k, 0, n);
        return (IList<IList<int>>)result;
    }
    
    private void proceed(List<int>prefix, int numofNumbers, int startIndex, int remaining)
    {   
        if(numofNumbers==0 && remaining==0)
        {
            result.Add((IList<int>)prefix);
            return;
        }
        
        if(startIndex>8 || remaining<0 || remaining<startIndex)
            return;
            
        //taking current number and proceed
        List<int>clone = new List<int>(prefix);
        clone.Add(startIndex+1);
        proceed(clone, numofNumbers-1, startIndex+1, remaining - (startIndex+1));
        
        //skipping current number and continue
        proceed(prefix, numofNumbers, startIndex+1, remaining);
            
    }
}