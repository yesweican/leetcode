using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q949
    {
        public List<int[]> permutations;
        int maxhour;
        int maxminute;

        public string LargestTimeFromDigits(int[] A)
        {
            permutations = new List<int[]>();
            List<int> emptyList = new List<int>();
            List<int> list = new List<int>() { 0, 1, 2, 3 };

            maxhour = -1;
            maxminute = -1;

            PopulatePermutations(emptyList, list);

            //Foreach permutation, Verify the Value is valid, 
            //Hour < 24, Minute < 60
            //if valid Compare to MAX
            foreach(var v in permutations)
            {
                int hour = A[v[0]] * 10 + A[v[1]];
                int minute = A[v[2]] * 10 + A[v[3]];
                if(hour<24 && minute<60)
                {
                    if(hour>maxhour || (hour==maxhour && minute>maxminute))
                    {
                        maxhour = hour;
                        maxminute = minute;
                    }
                }
            }
            if (maxhour == -1)
                return string.Empty;
            else
            {
                string result = maxhour.ToString("00") + ":" + maxminute.ToString("00");
                return result;
            }
        }

        private void PopulatePermutations(List<int>prefix, List<int> l)
        {
            if(l.Count==1)
            {
                prefix.Add(l[0]);
                permutations.Add(prefix.ToArray());
                return;
            }

            foreach(var v in l)
            {
                List<int> newPrefix = new List<int>(prefix);
                List<int> newL = new List<int>(l);
                newPrefix.Add(v);
                newL.Remove(v);
                PopulatePermutations(newPrefix, newL);
            }

        }

    }
}
