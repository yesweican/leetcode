using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    public class q797
    {
        List<IList<int>> results;
        Dictionary<int, int[]> graph2;
        int goal;

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            results = new List<IList<int>>();

            graph2 = new Dictionary<int, int[]>();
            goal = graph.Length - 1;

            for(int i=0; i<graph.Length; i++)
            {
                graph2.Add(i, graph[i]);
            }

            List<int> prefix = new List<int>();

            Explore(prefix, 0);

            return ((IList<IList<int>>)results);

        }

        private void Explore(List<int>prefix, int current)
        {
            List<int> newPrefix = new List<int>(prefix);
            newPrefix.Add(current);

            if (goal == current)
            {
                results.Add((IList<int>)newPrefix);
                return;
            }

            foreach(var v in graph2[current])
            {
                Explore(newPrefix, v);
            }
        }

    }
}
