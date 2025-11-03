public class Solution {
    int [][] dp = null;
    public int MaxProduct(string[] words) {
        dp = new int[words.Length][];
        
        for(int i = 0; i<words.Length; i++){
            dp[i] = new int[26];
            char[] buffer =  words[i].ToCharArray();
            for(int j=0; j<buffer.Length; j++)
            {
                char c = buffer[j];
                int temp = (int) (c-'a');
                dp[i][temp] = 1;
            }
        }
    
        int result = Int32.MinValue;

        for(int i=0; i<(words.Length-1); i++){
            int l1 = words[i].Length;
            for(int j=i+1;j<words.Length; j++)
            {
                if(!overlapping(i, j))
                {
                    int l2 = words[j].Length;
                    int temp = l1*l2;

                    if((temp)>result)
                        result=temp;
                }
            }
        }
        
        return result==Int32.MinValue?0:result;
    }
    
    private bool overlapping(int n1, int n2)
    {
        int[] a1 = dp[n1];
        int[] a2 = dp[n2];
        
        for(int i=0; i<26; i++){
            if (a1[i]==1 && a2[i]==1)
                return true;
        }
        
        return false;
    }
}