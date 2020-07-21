using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q014
    {
        public string LongestCommonPrefix(string[] strs)
        {

            if (strs == null || strs.Length == 0)
                return "";
            //int max = 0;
            StringBuilder builder = new StringBuilder();

            char[] characters = strs[0].ToCharArray();
            if (characters.Length == 0) return "";

            for (int pos = 0; pos < characters.Length; pos++)
            {
                bool validated = true;

                for (int n = 1; n < strs.Length; n++)
                {
                    if (pos > (strs[n].Length - 1))
                    {
                        validated = false;
                        break;
                    }
                    else
                    {
                        if (characters[pos] != strs[n][pos])
                        {
                            validated = false;
                            break;
                        }

                    }

                }

                if (!validated)
                {
                    //max = pos - 1;
                    break;
                }
                else
                {
                    //max = pos;
                    builder.Append(characters[pos]);
                }
            }

            //if (max == -1)
            //{
            //    return "";
            //}
            //else
            //{
            ////////////SubString is VERY SLOW
            //    return strs[0].Substring(0, max + 1);
            //}
            return builder.ToString();

        }
    }
}
