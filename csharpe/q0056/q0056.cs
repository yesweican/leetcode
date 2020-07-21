using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeChallenge
{
    public class q056
    {
        public int[][] Merge(int[][] intervals) 
        {
           
            if(intervals==null||intervals.Length==0)
                return new int[0][];
        
            Array.Sort<int[]>(intervals,(c1, c2)=>(c1[0].CompareTo(c2[0])));

            bool letscontinue=true;
            while(letscontinue)
            {
                letscontinue=false;
                List<int[]> temp = new List<int[]>();

                int[] current=null;
                foreach(var interval in intervals)
                {
                    if(current==null)
                    {
                        current=interval;
                        continue;
                    }

                    if(current[1]>=interval[0])
                    {
                        if(current[1]<interval[1])
                        {
                            current[1]=interval[1];
                        }

                        letscontinue=true;
                    }
                    else
                    {
                        temp.Add(current);
                        current=interval;
                    }
                }

                temp.Add(current);
                intervals=temp.ToArray();
            }
            return intervals;
        }//end of method


        /// <summary>
        /// Just one LOOP, so O(N)?! or O(NLogN)?
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] MergeBetter(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[0][];

            Array.Sort<int[]>(intervals, (c1, c2) => (c1[0].CompareTo(c2[0])));

            List<int[]> outputarr = new List<int[]>();
            int currentoutput = -1;

            foreach (var interval in intervals)
            {
                if (outputarr.Count == 0)
                {
                    outputarr.Add(interval);
                    currentoutput = 0;
                    continue;
                }

                if (outputarr[currentoutput][1] >= interval[0])
                {
                    if (outputarr[currentoutput][1] < interval[1])
                    {
                        outputarr[currentoutput][1] = interval[1];
                    }
                }
                else
                {
                    outputarr.Add(interval);
                    currentoutput++;
                }
            }

            return outputarr.ToArray();
        }//end of method

    }//end of class
}
