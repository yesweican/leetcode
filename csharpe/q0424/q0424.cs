using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Longest Repeating Characters Replacement
    /// </summary>
    public class q424
    {
        public int CharacterReplacement(string s, int k)
        {
            int N = s.Length;
            int[] char_counts = new int[26];

            int window_start = 0;
            int max_length = 0;
            int max_count = 0;

            for (int window_end = 0; window_end < N; window_end++)
            {
                int cindex = s[window_end] - 'A';
                char_counts[cindex]++;
                int current_count = char_counts[cindex];
                max_count = Math.Max(max_count, current_count);

                while(window_end-window_start+1-max_count>k)
                {
                    //char_counts[s[window_start] - 'A']--;
                    //window_start++;
                    int temp = char_counts[s[window_start] - 'A'];
                    char_counts[s[window_start] - 'A'] = temp - 1;
                    window_start++;
                    //I felt I need to update the Max_Count here!!!
                    //And to use Max(). we need System.Linq
                    if (temp == max_count)
                        max_count = char_counts.Max();
                }

                max_length = Math.Max(max_length, window_end- window_start + 1);
            }

            return max_length;


        }
    }
}
