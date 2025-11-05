public class Solution {
    public char FindTheDifference(string s, string t) {
        Dictionary<char, int>dict = new Dictionary<char, int>();

        foreach(char c in s.ToCharArray())
        {
            if(!dict.Keys.Contains(c))
            {
                dict.Add(c, 1);
            }
            else
            {
                dict[c]++;
            }
        }

        foreach(char d in t.ToCharArray())
        {
            if(!dict.Keys.Contains(d))
                return d;
            else
            {
                dict[d]--;
                if(dict[d]<0)
                   // dict.Remove(d);
                   return d;
            }
        }

        return '_';
    }
}