using System;
//using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LeetcodeNaughton
{
    public class q819
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> bannedwords = new HashSet<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string str in banned)
                bannedwords.Add(str);

            string cleanparagraph = Regex.Replace(paragraph, "[^a-zA-Z]", " ");
            string[] words = cleanparagraph.ToLower().Split(" ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);

            int most = 0;
            foreach (var word in words)
            {
                if (!bannedwords.Contains(word))
                {
                    if (!dict.ContainsKey(word))
                    {
                        dict.Add(word, 0);
                    }

                    dict[word] = dict[word] + 1;
                    if (most < dict[word]) 
                        most = dict[word];
                }
            }

            return dict.Where(p => p.Value == most).FirstOrDefault().Key;
        }
    }
}
