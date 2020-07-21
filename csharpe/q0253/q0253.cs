using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{

 
    public class q253
    {
        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        public class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval a, Interval b)
            {
                return a.start == b.start ? a.end - b.end : a.start - b.start;
            }
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;
            if (intervals.Length == 1) return 1;

            Array.Sort(intervals, new IntervalComparer());

            // the ideal datastructure to solve this a priority queue, however C# doesn't have impletemented it yet
            // so I'll use a sorted list here
            var rooms = new List<int>(intervals.Length);
            var max = 1;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (i == 0)
                {
                    rooms.Add(intervals[0].end);
                }
                else
                {
                    if (intervals[i].start >= rooms[0])
                    {
                        rooms.RemoveAt(0);
                    }

                    int index = rooms.BinarySearch(intervals[i].end);
                    rooms.Insert(index < 0 ? ~index : index, intervals[i].end);
                }

                max = Math.Max(max, rooms.Count);
            }

            return max;
        }
    }
}
