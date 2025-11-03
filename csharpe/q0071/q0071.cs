public class Solution {
    public string SimplifyPath(string path) {
        string[] subs = path.Split('/');
        List<string> buffer = new List<string>();
        
        for(int i=0; i<subs.Length;i++)
        {
            if(String.IsNullOrEmpty(subs[i]))
                continue;
            
            if(subs[i]!="." && subs[i]!="..")
            {
                buffer.Add(subs[i]);
            }
            else
            {
                if(subs[i]==".." && buffer.Count > 0)
                {
                    int index = buffer.Count;
                    buffer.RemoveAt(index-1);
                }
            }
        }
        
        StringBuilder builder = new StringBuilder();
        for(int i=0; i<buffer.Count; i++)
        {
            builder.Append("/");
            builder.Append(buffer[i]);
        }
        
        string temp = builder.ToString();
        if(temp == "")
            temp = "/";
        
        return temp;
    }
}