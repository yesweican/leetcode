using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q243
    {
        public int ShortestDistance(string[] words, string word1, string word2) 
        {
            int lastword1=-1; int lastword2=-1;
            int mindistance=int.MaxValue;
            for(int i=0; i<words.Length; i++)
            {
                if(words[i]==word1)
                {
                    lastword1=i;

                    if(lastword2!=-1)
                    {
                        if((i-lastword2)<mindistance)
                            mindistance=i-lastword2;
                    }
                }
        
                if(words[i]==word2)
                {
                    lastword2=i;

                    if(lastword1!=-1)
                    {
                        if((i-lastword1)<mindistance)
                            mindistance=i-lastword1;
                    }
                }
            }//end of for
            return mindistance;
   
        }//end of function
    }
}
