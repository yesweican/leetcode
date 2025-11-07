public class Solution {
    int[] data;
    List<IList<int>> result;
    HashSet<string>hash;
    public IList<IList<int>> FindSubsequences(int[] nums) {
        data = nums;
        hash=new HashSet<string>();
        result = new List<IList<int>>();
        List<int> temp = new List<int>();
        process(temp, 0, -101);
        return (IList<IList<int>>) result;
    }

    private void process(List<int>prefix, int index, int last)
    {
        List<int>newPrefix = new List<int>(prefix);

        int d = data[index];
        if(d>=last)
        {
            prefix.Add(d);
            if(index == (data.Length-1))
            {
                 if(prefix.Count>1)
                 {
                    string h = generateHash(prefix);                    
                    if(!hash.Contains(h))
                    {
                        result.Add((IList<int>)prefix);
                        hash.Add(h);                      
                    }
   
                 }              
            }

            else //now prefix exteneded
                process(prefix, index+1, d);
        }

        //skipping current
        //go with original prefix        
        if(index==(data.Length-1))
        {
            if(newPrefix.Count>1)
            {
                string h = generateHash(newPrefix);                    
                if(!hash.Contains(h))
                {
                    result.Add((IList<int>)newPrefix);
                    hash.Add(h);                       
                }
 
            }             
        }
        else 
            process(newPrefix, index+1, last);
    }

    private string generateHash(List<int>l)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(l[0].ToString());
        for(int i=1; i<l.Count;i++)
        {
            builder.Append("-"+l[i].ToString());
        }
        return builder.ToString();
    }
}