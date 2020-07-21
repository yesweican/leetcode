using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q245
    {
        public int ShortestDistance(string[] words, string word1, string word2)
        {
            if (word1 == word2)
                return ShortestDistanceOne(words, word1);

            int lastword1 = -1; int lastword2 = -1;
            int mindistance = int.MaxValue;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word1)
                {
                    lastword1 = i;

                    if (lastword2 != -1)
                    {
                        if ((i - lastword2) < mindistance)
                            mindistance = i - lastword2;
                    }
                }

                if (words[i] == word2)
                {
                    lastword2 = i;

                    if (lastword1 != -1)
                    {
                        if ((i - lastword1) < mindistance)
                            mindistance = i - lastword1;
                    }
                }
            }//end of for
            return mindistance;

        }//end of function

        //Finding the Shortest GAP not the Longest Gap
        private int ShortestDistanceOne(string[] words, string word1)
        {
            int min = 0;
            int lastindex = -1;

            for(int i=0; i<words.Length; i++)
            {
                if(words[i]==word1)
                {
                    if(lastindex == -1)
                    {
                        lastindex=i;
                    }
                    else
                    {
                        if((i-lastindex)<min)
                        {
                            min=i-lastindex;
                            lastindex=i;
                        }
                    }
                }
            }
            return min;
        }
    }
}
