using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q727
    {
        public string MinWindow(string S, string T)
        {
            if (S.Length < T.Length) return "";

            bool satisfied = false;
            int minLength = int.MaxValue;
            int minEndIndex = -1;
            int matchCountNeeded = 0;
            int matchCount = 0;
            Dictionary<char, int> charDict = new Dictionary<char, int>();
            char[] characters1 = S.ToCharArray(); //Chars of S
            char[] characters2 = T.ToCharArray(); //Chars of T


            //prepare the charDict using T
            for (int i = 0; i < characters2.Length; i++)
            {
                char c=characters2[i];
                if(charDict.Keys.Contains<char>(c))
                {
                    charDict[c] = charDict[c] + 1;
                }
                else
                {
                    charDict.Add(c, 1);
                }

                matchCountNeeded++;
            }

            int left = 0; //this this the pointers that moves whiles Satisfied;
            int right = 0; //this is the pointer that moves whiles the Unsatisfied; 

            while (right < characters1.Length)
            {
                if (!satisfied)
                {
                    char c2 = characters1[right];
                    if (charDict.Keys.Contains(c2))
                    {
                        charDict[c2]--;
                        matchCount++;
                        //check the status of CharDict
                        if (matchCount >= matchCountNeeded)
                            satisfied = IsCharDictSatisfied(charDict);
                    }
                }
                else 
                {
                    //if current status is Satisfied, move the front pointer 
                    //to see whether we could remove some unneeded characters from front
                    while (satisfied)
                    {
                        char c3=characters1[left];
                        if (charDict.Keys.Contains(c3))
                        {
                            //matchcount>=matchCountNeeded at least
                            if (matchCount == matchCountNeeded)
                            {
                                //if we barely meet requirement;
                                if(minLength>(right - left + 1))
                                {
                                    minLength=right-left+1;
                                    minEndIndex = right;
                                }
                                satisfied = false;

                                charDict[c3]--;
                                matchCount--;

                            }
                            else
                            {   //update charDict
                                charDict[c3]--;
                                bool temp=IsCharDictSatisfied(charDict);
                                //if this change would invalidate the charDict;
                                if(temp==false)
                                {
                                    if (minLength > (right - left + 1))
                                    {
                                        minLength = right - left + 1;
                                        minEndIndex = right;
                                    }
                                    satisfied = false;
                                }

                                //charDict[c3]--;
                                matchCount--;
                            }
                        }

                        left++;
                        
                    }//end of inner while loop
                }

                if(!satisfied)//if and only if
                   right++;

            }//end of outer loop

            return minLength==int.MaxValue? "" : S.Substring(minEndIndex-minLength+1,minLength);

        }

        //invoke this only if MatchCount met and ran into Character in the CharDict
        private bool IsCharDictSatisfied(Dictionary<char, int> charDict)
        {
            bool result=true;
            for(int i=0; i<charDict.Count; i++)
            {
                if(charDict.ElementAt(i).Value>0)
                    return false;
            }

            return result;
        }


    }
}
