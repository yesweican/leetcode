public class Solution {
    public bool IsIsomorphic(string s, string t) {
        char[] map = new char[256];
        for(int i=0; i<256; i++) {
            map[i] = '\0';
        }

        for(int i=0; i<s.Length; i++) {
            char c1 = s[i];
            char c2 = t[i];
            int j = (int)(c1-'\0');
            if(map[j]=='\0') {
                for(int k=0; k<256; k++) {
                    if(map[k]==c2)
                        return false;
                }
                map[j] = c2;
            } else {
                if(map[j]!=c2)
                    return false;
            }
        }

        return true;
    
    }
}