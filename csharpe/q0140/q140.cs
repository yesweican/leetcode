using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q140
    {
        HashSet<string> dict;
        Dictionary<string, List<string>> wordBreaks;

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            dict = new HashSet<string>();
            wordBreaks = new Dictionary<string, List<string>>();

            foreach(var v in wordDict)
            {
                dict.Add(v);
            }

            RecursiveWordBreak(s);

            return ((IList<string>)wordBreaks[s]);
        }

        private void RecursiveWordBreak(string s)
        {
            List<string> result = new List<string>();

            //if (wordBreaks.ContainsKey(s))
             //   return;

            for (int i = 0; i < s.Length; i++)
            {
                string temp = s.Substring(i, s.Length - i);

                if(dict.Contains(temp))
                {
                    if (i == 0)
                        result.Add(temp);
                    else
                    {
                        string temp2 = s.Substring(0, i);

                        if(!wordBreaks.ContainsKey(temp2))
                        {
                            RecursiveWordBreak(temp2);
                        }

                        foreach(var v in wordBreaks[temp2])
                        {
                            result.Add(v + " " + temp);
                        }

                    }
                }
            }

            wordBreaks.Add(s, result);
        }

    }
}
