using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q252
    {
        /// <summary>
        /// Using IComparer
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public bool CanAttendMeetings(int[][] intervals)
        {
            List<Interval> list = new List<Interval>();
            IntervalComparer cp = new IntervalComparer();

            for (int i = 0; i < intervals.Length; i++)
            {
                list.Add(new Interval(){Start=intervals[i][0], End=intervals[i][1]});
            }

            ///sort using the custom comparer
            list.Sort(cp);

            for (int i = 0; i < (intervals.Length - 1); i++)
            {
                if (list[i].End > list[i + 1].Start)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Using Comparison
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public bool CanAttendMeetings2(int[][] intervals)
        {

            Array.Sort(intervals, new Comparison<int[]>((x, y) => { return x[0] < y[0] ? -1 : (x[0] > y[0] ? 1 : 0); }));

            for (int i = 0; i < (intervals.Length - 1); i++)
            {
                //if an earlier event finishes AFTER a later event started
                if (intervals[i][1] > intervals[i + 1][0])
                    return false;
            }

            return true;
        }
    }

    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

    }

    public class IntervalComparer: IComparer<Interval>
    {
        /// <summary>
        /// A signed integer that indicates the relative values of x and y:
        ///    - If less than 0, x is less than y.
        ///    - If 0, x equals y.
        ///    - If greater than 0, x is greater than y.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>
        /// </returns>
        public int Compare(Interval a, Interval b)
        {
            //
            if (a.Start < b.Start)
                return -1;
            else
            {
                if (a.Start == b.Start)
                {
                    if (a.End < b.End)
                        return -1;
                    else
                    {
                        if (a.Start == b.End)
                            return 0;
                    }
                }
            }

            return 1;
        }


    }
}
