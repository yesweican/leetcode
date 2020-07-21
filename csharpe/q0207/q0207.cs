using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q207
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            bool[] visited = new bool[numCourses];
            bool[] stack = new bool[numCourses];
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();

            //preprocess
            for(int i=0; i<prerequisites.Length; i++)
            {
                if(!graph.ContainsKey(prerequisites[i][0]))
                {
                    //first entry
                    graph.Add(prerequisites[i][0], new List<int>() { prerequisites[i][1] });
                }
                else
                {
                    //more prereq entries
                    var temp = graph[prerequisites[i][0]];
                    temp.Add(prerequisites[i][1]);
                }
            }


            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i] == false)
                {
                    if (DFS(graph, visited, stack, i))
                        return false;
                }

            }

            return true;
        }

        //these functions either return Cycle Existed or Cycle NOT Existed!!!
        private bool DFS(Dictionary<int, List<int>> graph, bool[] visited, bool[] stack, int course)
        {
            visited[course] = true;
            stack[course] = true;

            foreach (var v in graph[course])
            {
                if(visited[v]==false)
                {
                    if(DFS(graph, visited, stack, v))
                    {
                        return true;
                    }
                }
                else//visted[v]==true
                {
                    if (stack[v]==true)
                        return true;//Cycle Existed!!!
                }
            }

            stack[course] =  false;

            return false;
        }
    }
}
