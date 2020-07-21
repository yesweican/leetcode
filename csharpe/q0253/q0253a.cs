using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class q253a
    {
        /// <summary>
        /// https://leetcode.com/problems/meeting-rooms-ii/discuss/120119/C%3A-Easy-to-Understand-Intuitive-Solution-with-Explanation.-(Accepted)
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int MinMeetingRooms(int[][] intervals)
        {
            int[] starts = intervals.Select(x => x[0]).ToArray();
            int[] ends = intervals.Select(x => x[1]).ToArray();

            Array.Sort(starts);
            Array.Sort(ends);

            int rooms = 0;
            int endItr = 0;//endTimesIterator 
            for (int i = 0; i < starts.Length; i++)
            {
                //Check if startTime of current meeting is after endTime of meeting that is suppose to end first.
                if (starts[i] < ends[endItr])
                {
                    rooms++;
                }
                else
                {
                    endItr++;
                }
            }

            return rooms;
        }
    }
}
