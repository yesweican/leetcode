using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q267
    {
        public IList<string> GeneratePalindromes(string s)
        {
            char[] characters = s.ToCharArray();
            List<string> results = new List<string>();
            //Count all the characters into a Dictionary
            Dictionary<char, int> characterCounts = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char temp=characters[i];
                if (characterCounts.ContainsKey(temp))
                {
                    characterCounts[temp] = characterCounts[temp] + 1;
                }
                else
                {
                    characterCounts.Add(temp, 1);//being first of a certain char
                }
            }

            if (characterCounts.Count == 1)
            {
                results.Add(s); return results;
            }

            //then count the ODD occurence of character, if MORE than 1 return EMPTY list
            int oddCount = 0;
            List<char> charSource=new List<char>();
            string charMiddle="";
            for (int j = 0; j < characterCounts.Count; j++)
            {
                if (characterCounts.ElementAt(j).Value % 2 == 1)
                {
                    //if more than 1 odd character, it cannot be used for Palindrone
                    if (oddCount == 1)
                        return results;
                    else
                    {
                        oddCount++;
                        charMiddle = characterCounts.ElementAt(j).Key.ToString();
                        int charcount = characterCounts.ElementAt(j).Value-1;
                        char c = characterCounts.ElementAt(j).Key;
                        for (int i = 0; i < (charcount) / 2; i++)
                        {
                            charSource.Add(c);
                        }
                    }
                }
                else
                {
                    //put all the even numbered characters into a string-1/2 of the number
                    int charcount=characterCounts.ElementAt(j).Value;
                    char c = characterCounts.ElementAt(j).Key;
                    for (int i = 0; i < (charcount)/2; i++)
                    {
                        charSource.Add(c);
                    }
                }
            }

            //generate the permutation of this halfstring
            //if there is one odd character, put it into middle 
            PermutationEngine engine = new PermutationEngine(charSource.ToArray());

            results = engine.GetPermutations();

            //foreach abc, turn it into "abc"+m+"cba"
            for(int i=0; i<results.Count; i++)
            {
                results[i] = s + charMiddle + s.Reverse();
            }

            return results;
        }
    }

    public class PermutationEngine
    {
        char[] source;
        List<string> Results=null;
        HashSet<string> set=null;

        public PermutationEngine(char[] characters)
        {
            Results=new List<string>();
            set = new HashSet<string>();

            source=characters;
        }

        public List<string> GetPermutations()
        {
            populate(source, 0, source.Length-1);
            return Results;
        }

        void populate(char[] a, int left, int right) 
        {
            if(left==right)
            {   
                string s = new string (a);
                if(!set.Contains(s))
                {
                   set.Add(s);
                   Results.Add(s);
                }
            }
            else
                for(int i=left;i<=right;i++)
                {
                    swap(a,left,i);
                    populate(a,left+1, right);
                    swap(a,left,i);
                }
        }

        void swap(char[] a, int i, int x) 
        {
            char t=a[i];
            a[i]=a[x];
            a[x]=t;
        }

    }
}
