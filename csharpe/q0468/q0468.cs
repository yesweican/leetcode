public class Solution {
    
    public string ValidIPAddress(string IP) {
        char[] splitters1 = ".".ToCharArray();
        char[] splitters2 = ":".ToCharArray();

        string[] parts1 = IP.Split(splitters1);

        if (parts1.Length == 4)
        {
            if (ValidIPv4(parts1))
                return "IPv4";
            else
                return "Neither"; 
        }

        string[] parts2 = IP.Split(splitters2);

        if(parts2.Length==8)
        {
            if(ValidIPv6(parts2))
                return "IPv6";
        }

        return "Neither";       
    }
    
    private bool ValidIPv4(string[] parts)
    {
        for (int i= 0; i<4; i++ )
        {
            string temp = parts[i].ToLower();
            if(temp.Trim().Length==0||temp.Trim().Length>3)
                return false;
                
            string map="abcdefghijklmnopqrstuvwxyz-";
                
            for(int j=0; j<temp.Length; j++)
            {
                if(map.Contains(temp[j]))
                return false;                        
            }

            if (temp.Length > 1 && temp.StartsWith("0"))
                return false;

            int n;
            if (Int32.TryParse(temp, out n))
            {
                if (n > 255)
                    return false;
            }
        }

        return true;
    }

    private bool ValidIPv6(string[] parts2)
    {
        for(int i=0; i<8; i++)
        {
            string temp = parts2[i];
            if (!ValidIPv6Part(temp))
                return false;
        }
        return true;
    }

    private bool ValidIPv6Part(string part)
    {
        if(part.Trim().Length==0)
            return false;
            
        string map = "0123456789abcdef";
        string newpart = part.ToLower();
        
        //if(part.Length>1 && part.StartsWith("0"))
         //   return false;           

        if (part.Length < 5)
        {
            for (int j = 0; j < newpart.Length; j++)
            {
                if (!map.Contains(newpart[j]))
                    return false;
            }
            return true;
        }
             
            return false;
    }
}