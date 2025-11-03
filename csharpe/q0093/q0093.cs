public class Solution {
    public IList<string> RestoreIpAddresses(string s)
    {

        List<string> result = new List<string>();
        if(s.Length<4)
            return result;        
        int n = s.Length;
        string s1, s2, s3, s4;
        for (int i = 1; i <= 3; i++)
        {
            if (!validate(s, 0, i - 1))
                continue;
            s1 = s.Substring(0, i);
            for (int j = 1; j <= 3; j++)
            {
                if ((i+j)>(n-2)||!validate(s, i, i + j - 1))
                    continue;
                s2 = s.Substring(i, j);
                for (int k = 1; k <= 3; k++)
                {
                    if ((i + j + k - 1)>(n-2) || !validate(s, i + j, i + j + k - 1))
                        continue;
                    s3 = s.Substring(i + j, k);
                    int l = n - (i + j + k);
                    if (l > 3)
                        continue;
                    if (!validate(s, i + j + k, n - 1))
                        continue;
                    s4 = s.Substring(i + j + k, l);
                    string address = s1 + "." + s2 + "." + s3 + "." + s4;
                    result.Add(address);
                }
            }
        }

        return result;
    }

    private bool validate(string s, int x, int y)
    {
        string s1 = s.Substring(x, y - x + 1);
        if ((y - x) > 0 && s1[0] == '0')
            return false;
        if (Int32.TryParse(s1, out int n))
        {
            if (n > 255)
                return false;
            return true;
        }
        else
            return false;

    }
}