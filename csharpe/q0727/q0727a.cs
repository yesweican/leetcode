using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q727a
    {

        public string MinWindow(string S, string T)
        {
            if (S.Length < T.Length) return "";

            if (T.Length == 1)
            {
                if (S.Contains(T))
                    return T;
                else
                    return "";
            }

            bool satisfied = false;
            int minLength = int.MaxValue;
            int minEndIndex = -1;
            int matchCountNeeded = 0;
            int matchCount = 0;
            HashSet<char> set = new HashSet<char>();

            char[] characters1 = S.ToCharArray(); //Chars of S
            char[] characters2 = T.ToCharArray(); //Chars of T

            //prepare the charDict using T
            for (int i = 0; i < characters2.Length; i++)
            {
                char c = characters2[i];
                if (!set.Contains<char>(c))
                {
                    set.Add(c);
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
                    if (set.Contains(c2))
                    {
                        matchCount++;
                        //check the status
                        if ((matchCount >= matchCountNeeded) && (c2 == characters2[characters2.Length - 1]))
                        {
                            satisfied = IsOrderlySatisfied(characters1, left, right, characters2);
                        }
                    }
                }
                else
                {
                    //if current status is Satisfied, move the front pointer 
                    //to see whether we could remove some unneeded characters from front
                    while (satisfied)
                    {
                        char c3 = characters1[left];
                        if (set.Contains(c3))
                        {
                            //if removing one more character in the set;
                            matchCount--;
                        }
                        left++;

                        //update if matchCount < matchCountNeeded
                        if (matchCount < matchCountNeeded)
                        {
                            if (minLength > (right - (left - 1) + 1))
                            {
                                minLength = right - (left - 1) + 1;
                                minEndIndex = right;
                            }
                            satisfied = false;
                        }
                        else//or recheck the status
                        {
                            //and after 
                            bool temp = IsOrderlySatisfied(characters1, left, right, characters2);
                            //if this change would invalidate the substring;
                            if (temp == false)
                            {
                                if (minLength > (right - (left - 1) + 1))
                                {
                                    minLength = right - (left - 1) + 1;
                                    minEndIndex = right;
                                }
                                satisfied = false;
                            }
                        }

                    }//end of inner while loop
                }

                if (!satisfied)//if and only if
                    right++;

            }//end of outer loop

            return minLength == int.MaxValue ? "" : S.Substring(minEndIndex - minLength + 1, minLength);

        }

        //invoke this only if MatchCount met and ran into Character in the CharDict
        private bool IsOrderlySatisfied(char[] chararr1, int startIndex, int endIndex, char[] charArr2)
        {
            bool result = true;
            int pointer1 = endIndex - 1; int pointer2 = charArr2.Length - 2;
            int matchNeeded = charArr2.Length-1;//last char already matched

            while (pointer2 >= 0)
            {
                char c = charArr2[pointer2];
                while (pointer1 >= startIndex)
                {
                    if (c != chararr1[pointer1])
                    {
                        pointer1--;
                    }
                    else
                    {
                        //c!=chararr1[pointer1]
                        pointer1--;
                        pointer2--;
                        matchNeeded--;
                        break;
                    }
                }//end of inner loop

                if (matchNeeded == 0)
                    return true;

                if ((pointer1 < startIndex) && (matchNeeded > 0))
                    return false;
            }//end of outer loop

            if (matchNeeded > 0)
                return false;

            return result;
        }
    }
}
