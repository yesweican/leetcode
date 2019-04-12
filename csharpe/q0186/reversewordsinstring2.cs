public class Solution {
    public void ReverseWords(char[] str) {
             ReverseWord(ref str, 0, str.Length - 1);

            int start = 0;
            int end;
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == ' ')
                {
                    end = j - 1;
                    ReverseWord(ref str, start, end);
                    start = j + 1;
                }
                else
                {
                    if (j == (str.Length - 1))
                    {
                        end = str.Length-1;
                        ReverseWord(ref str, start, end);
                    }
                }
            }       
    }
    
                public void ReverseWord(ref char[] str, int start, int end)
            {
                int changes = (int)((end - start + 1) / 2);
                for (int i= 0; i < changes; i++)
                {
                    char temp = str[start+i];
                    str[start + i] = str[end-i];
                    str[end-i] = temp;

                }

            }
}