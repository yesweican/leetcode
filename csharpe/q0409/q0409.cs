public class Solution {
    public int LongestPalindrome(string s) 
    {
        Dictionary<char, int>dict=new Dictionary<char, int>();
        char[] characters = s.ToCharArray();
        
        for(int i=0; i<characters.Length; i++)
        {
            if(!dict.ContainsKey(s[i]))
                dict.Add(s[i], 1);
            else
            {
                dict[s[i]]=dict[s[i]]+1;
            }
        }
        
        bool oddExists=false;
        int l=0;
        foreach(var v in dict)
        {
            if(v.Value % 2==1)
                oddExists=true;
            l+=(int)v.Value/2;
        }
        
        l=oddExists? (l*2+1) : l*2;
        
        return l;
            
    }
}