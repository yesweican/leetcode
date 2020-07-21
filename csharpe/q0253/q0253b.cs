using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q253b
    {
        public class CustomComparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return a.CompareTo(b);
            }
        }

        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;

            var minHeap = new SortedList<int, int>();
            intervals = intervals.OrderBy(i => i[0]).ToArray();
            minHeap.Add(intervals[0][1], intervals[0][0]);

            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= minHeap.First().Key)
                {
                    minHeap.RemoveAt(0);
                }

                minHeap.Add(intervals[i][1], intervals[i][0]);
            }


            return minHeap.Count;
        }
    }
}
