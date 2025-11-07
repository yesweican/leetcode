public class Solution {
    public string FrequencySort(string s) {
        int[] alphabet = new int[75];
        int[] freq = new int[75];

        for(int i=0; i<75; i++) {
            alphabet[i]=i;
        }

        for(int j=0; j<s.Length;j++) {
            int temp = (int)(s[j]-'0');
            freq[temp]++;
        }

        ////Array.Sort(alphabet, (a, b)=>freq[a]==freq[b]?(a-b):(freq[b]-freq[a]));
        Array.Sort(alphabet, (a, b)=>freq[b]-freq[a]);

        StringBuilder builder = new StringBuilder();

        for(int i=0; i<75; i++) {
            int temp = alphabet[i];
            char c = (char)('0'+temp);
            for(int j=0; j<freq[temp]; j++) {
                builder.Append(c);
            }
        }

        return builder.ToString();
    }
}