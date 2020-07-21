using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetcodeNaughton
{
    public class Point
    {
        public int[] coordinates;
        public int distance;
    }

    public class q973
    {
        public int[][] KClosest(int[][] points, int K)
        {
            List<Point> PointsWithDistances = new List<Point>();

            for (int i = 0; i < points.Length; i++)
            {
                PointsWithDistances.Add(new Point(){coordinates=points[i], distance=points[i][0]* points[i][0]+points[i][0]* points[i][0]});
            }

            //Sorting ASCENDING, closest in the Front!!!!
            PointsWithDistances.Sort((c1,c2)=>c1.distance.CompareTo(c2.distance));

            List<int[]>results = new List<int[]>();
            for(int i=0;i<K;i++)
            {
                results.Add(PointsWithDistances[i].coordinates);
            }

            return results.ToArray();

        }
    }
}
