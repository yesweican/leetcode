using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q886
    {
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            List<List<int>> graph = new List<List<int>>();

            for(int i=0; i<N; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i=0; i<dislikes.Length; i++)
            {
                int[] d = dislikes[i];
                graph[d[0] - 1].Add(d[1] - 1);
                graph[d[1] - 1].Add(d[0] - 1);
            }

            int[] colors = new int[N];
            for(int i=0; i<N; i++)
            {
                colors[i] = 0;
            }

            Queue<int> queue = new Queue<int>();
            for(int i=0; i<N; i++)
            {
                if(colors[i]==0)
                {
                    queue.Enqueue(i);
                    colors[i] = 1;//mark it Red
                }

                ///BFS traversal
                while(queue.Count>0)
                {
                    int cur = queue.Peek();
                    queue.Dequeue();

                    foreach(var v in graph[cur])
                    {
                        if (colors[v] == colors[cur])
                            return false;

                        if (colors[v] != 0)//already correctly colors
                            continue;

                        //color it if not yet colored, 1=>-1, -1=>1;
                        colors[v] = -colors[cur];
                        queue.Enqueue(v);
                    }
                }
                //might have multiple connected groups
            }

            return true;
        }

    }
}
