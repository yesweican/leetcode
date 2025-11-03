public class Solution {
    public int StrStr(string haystack, string needle) {
        char[] hayData = haystack.ToCharArray();
        char[] needleData = needle.ToCharArray();

        int left = 0, l = hayData.Length, n=needleData.Length;
        while(left<(l-n+1))
        {
            if(hayData[left]==needleData[0])
            {
                bool failed = false;
                for(int i=1; i<n; i++)
                {
                    if(hayData[left+i]!=needleData[i])
                    {
                        failed = true;
                        break;
                    }
                }

                if(failed==false)
                    return left;
            }

            left++;

        }

        return -1;
    }
}