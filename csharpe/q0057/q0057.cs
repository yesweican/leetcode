using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge05
{
    /// <summary>
    /// Insert Interval
    /// </summary>
    public class q057
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> buffer = new List<int[]>();

            int[] current;

            for(int i=0; i<intervals.Length; i++)
            {
                current = intervals[i];

                if(newInterval==null)
                {
                    buffer.Add(current);
                }
                else
                { //new Interval != null
                    if (newInterval[1] < current[0])
                    {
                        buffer.Add(newInterval);//no overlapp situation #1
                        buffer.Add(current);
                        newInterval = null;
                    }
                    else //newInterval[1]>=current[0]
                    {
                        if (current[1] < newInterval[0])
                        {//no overlapp situation #2
                            buffer.Add(current);
                        }
                        else //current[1]>=newInterval[0] && 
                        {
                            if(current[1]>newInterval[1])
                            {
                                if(current[0]<newInterval[0])
                                {
                                    //newInterval is inside of current
                                    buffer.Add(current);
                                    newInterval = null;
                                }
                                else //current[0]>=newInterval[0]
                                {
                                    //newInterval is merged into current
                                    current[0] = newInterval[0];
                                    buffer.Add(current);
                                    newInterval = null;
                                }
                            }
                            else//current[1]<=newInterval[1]
                            {
                                if (current[0] > newInterval[0])
                                {
                                    //do nothing=>current is inside of newInterval
                                }
                                else //current[0]<=newInterval[0]
                                {
                                    //current is merged into newInterval
                                    newInterval[0] = current[0];
                                }

                            }
                        }
                    }
                }//newInterval!=null
            }//end of For

            if(newInterval!=null)
            {
                buffer.Add(newInterval);
            }

            return buffer.ToArray();
        }
    }
}
