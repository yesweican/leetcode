using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q244
    {
        private string[] _words;
        private Dictionary<string, int> cache;

        public q244(string[] words)
        {
            _words = words;
            cache = new Dictionary<string, int>();
        }

        public int Shortest(string word1, string word2)
        {
            if (cache.ContainsKey(word1 + "-" + word2))
                return cache[word1 + "-" + word2];
            //if (cache.ContainsKey(word2 + "-" + word1))
            //   return cache[word2 + "-" + word1];

            int lastword1 = -1; int lastword2 = -1;
            int mindistance = int.MaxValue;
            for (int i = 0; i < _words.Length; i++)
            {
                if (String.CompareOrdinal(_words[i], word1)==0)
                {
                    lastword1 = i;

                    if (lastword2 != -1)
                    {
                        if ((i - lastword2) < mindistance)
                            mindistance = i - lastword2;
                    }
                }

                if (String.CompareOrdinal(_words[i], word2)==0)
                {
                    lastword2 = i;

                    if (lastword1 != -1)
                    {
                        if ((i - lastword1) < mindistance)
                            mindistance = i - lastword1;
                    }
                }
                if (mindistance == 1)
                    break;
            }//end of for

            cache.Add(word1 + "-" + word2, mindistance);
            cache.Add(word2 + "-" + word1, mindistance);

            return mindistance;
        }
    }

    /**
        * Your WordDistance object will be instantiated and called as such:
        * WordDistance obj = new WordDistance(words);
        * int param_1 = obj.Shortest(word1,word2);
        */
}
