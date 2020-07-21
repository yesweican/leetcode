using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q345
    {
        public string ReverseVowels(string s)
        {
            string vowels = "aAeEiIoOuU";

            char[] characters = s.ToCharArray();

            int forward = 0;
            int backward = characters.Length - 1;

            while (forward < backward)
            {
                //find the next vowel going forward
                while (forward < backward && !vowels.Contains(characters[forward]))
                {
                    forward++;
                }
                //find the next vowel going backward
                while (forward < backward && !vowels.Contains(characters[backward]))
                {
                    backward--;
                }

                //exchange the #N vowel with #N vowel from back
                if(forward < backward)
                {
                    char temp = s[forward];
                    characters[forward] = characters[backward];
                    characters[backward]=temp;
                }

                //need this to proceed!!!
                forward++; backward--;
            }

            //need to convert char[] to string
            return new string(characters);
        }

        public string ReverseVowels2(string s)
        {
            string vstr = "aAeEiIoOuU";
            char[] vowels = vstr.ToCharArray();

            char[] characters = s.ToCharArray();
            HashSet<char> set = new HashSet<char>();

            for(int i=0; i<vowels.Length; i++)
            {
                set.Add(vowels[i]);
            }

            int forward = 0;
            int backward = characters.Length - 1;

            while (forward < backward)
            {
                //find the next vowel going forward
                while (forward < backward && !set.Contains(characters[forward]))
                {
                    forward++;
                }
                //find the next vowel going backward
                while (forward < backward && !set.Contains(characters[backward]))
                {
                    backward--;
                }

                if(forward<backward)
                {
                    //exchange the #N vowel with #N vowel from back
                    char temp = s[forward];
                    characters[forward] = characters[backward];
                    characters[backward] = temp;
                }

                //need this to proceed!!!
                forward++; backward--;
            }

            //need to convert char[] to string
            return new string(characters);
        }
    }
}
