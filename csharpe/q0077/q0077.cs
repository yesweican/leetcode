public class Solution {
    List<IList<int>> result = null;
    int max = -1;
    public IList<IList<int>> Combine(int n, int k) {
        result = new List<IList<int>>();
        int[] temp = new int[0];
        max = n;
        process(1, temp, k);
        return (IList<IList<int>>)result;
    }
    
    private void process(int start, int[] currentArray, int remaining)
    {
        //Console.WriteLine("Start: {0}, Remaining: {1}, Remaining: {2}", start, max - start +1, remaining);

        if(remaining == 0)
        {
            result.Add((IList<int>)currentArray.ToList());
            return;
        }

        if(remaining > (max-start +1)) return;
        
        int[] newArray = new int[currentArray.Length + 1];
        for (int i = 0; i < currentArray.Length; i++)
        {
            newArray[i] = currentArray[i];
        }
        newArray[currentArray.Length] = start;
        
        if(remaining == 1)
        {
            //taking current would complete an answer
            result.Add((IList<int>)newArray.ToList());                   
        }
        else
        {
            if((start+1) <= max) process(start + 1, newArray, remaining - 1);
        }

        if ((start + 1) <= max) process(start + 1, currentArray, remaining);
        
    }
}