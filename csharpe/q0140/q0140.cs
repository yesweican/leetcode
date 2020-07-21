using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Word Break II - Recursive method, need to improve with DP
    /// </summary>
    public class q140
    {
        List<string> results;
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            results = new List<string>();

            process(s, wordDict, "");

            return (IList<string>)results;

        }

        private void process(string s, IList<string> wordDict,  string prefix)
        {
            if (s.Length == 0)
                return;

            List<string> prefixes = (List<string>)prefixWords(s, wordDict);
            string separator = prefix == "" ? "" : " ";


            for(int i=0;i<prefixes.Count; i++)
            {
                string tmp = prefixes[i];
                string s0 = s.Substring(tmp.Length);


                if (s0.Length == 0)
                    results.Add(prefix + separator + prefixes[i]);
                else
                    process(s0, wordDict, prefix + separator + prefixes[i]);
            }

        }

         private IList<string> prefixWords(string s, IList<string> wordDict)
        {
            List<string> prefixes = new List<string>();
            for (int i=0; i<wordDict.Count; i++)
            {
                if (s.StartsWith(wordDict[i]))
                    prefixes.Add(wordDict[i]);
            }

            return (IList<string>)prefixes;

        }

    }
}
