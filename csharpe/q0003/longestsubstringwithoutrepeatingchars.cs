public class Solution {
    public int NO_OF_CHARS = 256;
    public int LengthOfLongestSubstring(string str) {
            int n = str.Length;
            if (n==0) return 0;
        
            int cur_len = 1;    // length of current substring
            int max_len = 1;    // result
            int prev_index;        //  previous index
            int i;
            int[] visited = new int[NO_OF_CHARS];
            int startindex = 0, endindex = 0;
         
            for (i = 0; i < NO_OF_CHARS; i++) {
                visited[i] = -1;
            }
         
            visited[str[0]] = 0;
         
            for(i = 1; i < n; i++)
            {
                prev_index = visited[str[i]];
                if((prev_index == -1) ||(( i - cur_len) > prev_index))
                    cur_len++;
                else
                {
                    if (cur_len > max_len)
                    {
                        max_len = cur_len;
                        endindex = i - 1;
                        startindex = endindex - max_len + 1;
                    }
                 
                    cur_len = i - prev_index;
                }
             
                // update the index of current character
                visited[str[i]] = i;
            }
         
            if (cur_len > max_len)
            {
                max_len = cur_len;
                endindex = n - 1;
                startindex = endindex - max_len + 1;
            }

            //Console.WriteLine(str.Substring(startindex, max_len));
         
            return max_len;       
    }
}