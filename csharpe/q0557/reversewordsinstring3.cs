public class Solution {
    public string ReverseWords(string s) {
                 char[] splitters = new char []{' '};
                string[] words = s.Split(splitters);

                for (int i = 0; i < words.Length; i++)
                {
                    char[] temp = words[i].ToCharArray().Reverse().ToArray();
                    words[i] = new string(temp);
                }

                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < words.Length; i++)
                {
                    buffer.Append(words[i]);
                    if (i < (words.Length - 1))
                        buffer.Append(" ");
                }
                
                return buffer.ToString();       
    }
}