public class Solution {
    char[] data;
    public int LongestValidParentheses(string s)
    {
        data = s.ToCharArray();
        return Math.Max(CountForward(), CountBackward());

    }

    private int CountForward()
    {
        int l = 0, r = 0;
        int max = 0;
        for(int i=0; i<data.Length; i++)
        {
            if (data[i] == '(')
                l++;
            else
                r++;
            
            if (r == l)
            {
                if (max < (2 * r))
                    max = 2 * r;
            }
            
            if (r > l)
            {
                l = 0; r = 0;
            }

        }
        return max;
    }

    private int CountBackward()
    {
        int l = 0, r = 0;
        int max = 0;
        for (int i = data.Length-1; i >=0; i--)
        {
            if (data[i] == ')')
                r++;
            else
                l++;
            
            if (l == r)
            {
                if (max < (2 * l))
                    max = 2 * l;
            }
                
            if (l > r)
            {
                l = 0; r = 0;
            }

        }
        return max;
    }
}