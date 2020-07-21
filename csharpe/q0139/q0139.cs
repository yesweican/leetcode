using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q139
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> set = new HashSet<string>();

            for(int i=0; i<wordDict.Count; i++)
            {
                set.Add(wordDict[i]);
            }

            Console.WriteLine(set.Count.ToString());

            char[] characters = s.ToCharArray();

            return processWord(characters, 0, characters.Length - 1, set);

        }

        private bool processWord(char[] data, int start, int end, HashSet<string> dict)
        {
            if (start > end)
                return true;

            StringBuilder builder = new StringBuilder();

            int current = start; 
            while(current<=end)
            {
                builder.Append(data[current]);
                string temp = builder.ToString();
                Console.WriteLine(temp);

                bool result = false;
                if(dict.Contains(temp))
                {
                    result = processWord(data, current + 1, end, dict);
                    if (result)
                        return true;

                }

                current++;
            }

            return false;
        }
    }
}

