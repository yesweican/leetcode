public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        List<int[]> buffer = new List<int[]>();
        List<string> result = new List<string>();

        if(nums.Length==0)
            return result;

        int start = nums[0];
        int startindex = 0;

        int running =0;
        int index = startindex;
        int current;

        while(index<nums.Length)
        {
            current = nums[index];

            if(current != (start+running))
            {
                buffer.Add(new int[2]{start, nums[index-1]});

                start = nums[index];
                startindex = index;
                running  = 0;
            }

            running++;
            index = startindex + running;
        }

        buffer.Add(new int[2]{start, nums[index-1]});

        for(int i=0; i<buffer.Count; i++)
        {
            if(buffer[i][0]==buffer[i][1])
            {
                result.Add(buffer[i][0].ToString());
            }
            else
            {
                result.Add(String.Format("{0}->{1}", buffer[i][0], buffer[i][1]));
            }
        }

        return result;

    }
}