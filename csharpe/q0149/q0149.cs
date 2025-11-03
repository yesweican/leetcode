public class Solution {
    public int MaxPoints(int[][] points) {
        if(points.Length<3)
            return points.Length;

        Dictionary<string, HashSet<int[]>>dict = new Dictionary<string, HashSet<int[]>>();
        for(int i=0; i<points.Length-1; i++)
        {
            for(int j=i+1; j<points.Length; j++)
            {
                int[] p1 = points[i];
                int[] p2 = points[j];

                string key = generateHash(p1, p2);
                if(!dict.Keys.Contains(key))
                {
                    HashSet<int[]> temp = new HashSet<int[]>();
                    temp.Add(p1);
                    temp.Add(p2);
                    dict.Add(key, temp);
                }
                else
                {
                    if(!dict[key].Contains(p1))
                    {
                        dict[key].Add(p1);
                    }
                    if(!dict[key].Contains(p2))
                    {
                        dict[key].Add(p2);
                    }
                }
            }
        }

        int max = Int32.MinValue;
        foreach(var k in dict.Keys)
        {
            if(dict[k].Count>max)
                max = dict[k].Count;
        }

        return max;
    }

    private string generateHash(int[] p1, int[] p2)
    {
        //assuming p1!=p2
        if(p1[0]==p2[0])
        {
            return (p1[0]).ToString()+"-N";
        }

        if(p1[1]==p2[1])
        {
            return "N-"+p1[1].ToString();
        }

        float t0 = ((float)(p1[1]-p2[1])/(p1[0]-p2[0]));
        float t1 = ((float)(p1[1]*p2[0]-p2[1]*p1[0])/(p1[1]-p2[1]));
        float t2 = ((float)(p2[1]*p1[0]-p1[1]*p2[0])/(p1[0]-p2[0]));
        return t1.ToString()+"-"+t2.ToString()+"-"+t0.ToString();

    }
}