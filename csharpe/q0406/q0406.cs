using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Queue Reconstruction by Height
    /// </summary>
    public class q406
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            ////First Put input data in reverse height order.
            int l = people.Length;
            Array.Sort(people, new Comparison<int[]>((x, y) => { return (x[0] > y[0] || (x[0] == y[0] && x[1] < y[1]) ? -1 : (x[0] < y[0] || (x[0] == y[0] && x[1] > y[1]) ? 1 : 0)); }));

            ////When loading in descend order allow you to place the entry in correct place
            List<int[]> newList = new List<int[]>();
            for (int i = 0; i < l; i++)
            {
                ////data based on taller persons
                ////shorter entry does-not-matter 
                newList.Insert(people[i][1], new int[] { people[i][0], people[i][1] });
            }

            int[][] results = newList.ToArray();

            return results;
        }
    }
}
