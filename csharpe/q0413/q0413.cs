public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        if(nums.Length<3)
            return 0;
        
        int[] gaps = new int[nums.Length-1];
        
        for(int i=0; i<nums.Length-1; i++)
        {
            gaps[i] = nums[i+1]-nums[i];
        }
        
        List<int> runnings = new List<int>();
        
        int currentGap=gaps[0];
        int runLength =1;
        for(int i=1; i<gaps.Length;i++)
        {
            if(gaps[i]==currentGap)
                runLength++;
            else
            {
                Console.WriteLine(runLength.ToString());
                if(runLength>=2)
                    runnings.Add(runLength);
                currentGap = gaps[i];
                runLength=1;//reset to 1
            }
        }
        
        //don't forget the last one or first one
        runnings.Add(runLength);
        
        int result = 0;
        for(int j=0; j<runnings.Count; j++)
        {
            result += (runnings[j] * (runnings[j]-1))/2;
        }
        
        return result;
    }
}