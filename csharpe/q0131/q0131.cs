public class Solution {
    public IList<IList<string>> Partition(string s) {
        List<IList<string>> result = new List<IList<string>>();
        if(s.Length==0)
            return (IList<IList<string>>)result;
        
        for(int i=1; i<=s.Length; i++)
        {
            string part1 = s.Substring(0, i);
            string part2 = s.Substring(i, s.Length-i);
            
            if(IsPalindrome(part1))
            {
                if(part2.Length>0)
                {
                    List<IList<string>> temp = (List<IList<string>>) Partition(part2);

                    foreach(var list in temp)
                    {
                        list.Insert(0, part1);
                    }

                    result.AddRange(temp);                    
                }
                else //part2.Length == 0;
                {
                    List<string> collection = new List<string>();
                    collection.Add(part1);
                    result.Add((IList<string>)collection);
                }

            }
        }
        
        return result;
    }
    
    private bool IsPalindrome(string s)
    {
        if(s.Length==1) return true;
        
        int l=0; 
        int r=s.Length-1;
        
        while (l<r)
        {
            if(s[l]!=s[r])
                return false;
            
            l++; r--;
        }
        
        return true;
    }
}