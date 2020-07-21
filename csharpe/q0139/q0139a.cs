using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// DP method of the Word Break, O(N2)
    /// </summary>
    public class q139a
    {
        public bool WordBreak(string s, IList<string> wordDict)
        { 
            /// isWordBreak[i] == true means 
            /// s[0]..s[i-1] is breakable
            bool[] isWordBreak = new bool[s.Length + 1];
            isWordBreak[0] = true;

            for(int i=0; i<s.Length+1; i++)
            {
                for(int j=0; j<i; j++)
                {
                    if (!isWordBreak[j])
                        continue;
                    ///check s[j]..s[i-1] is in the wordDict list
                    if(wordDict.Contains(s.Substring(j, i-j)))
                    {
                        isWordBreak[i] = true;
                        break;
                    }

                }
            }

            return isWordBreak[s.Length];
        }
    }
}
