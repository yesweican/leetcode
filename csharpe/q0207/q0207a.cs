using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q207a
    {
        public bool CanFinishDFS(int numCourses, int[,] prerequisites)
        {
            if (prerequisites.GetLength(0) == 0)
                return true;

            bool[] visited = new bool[numCourses];
            List<int>[] graph = new List<int>[numCourses];

            for (int i = 0; i <= numCourses - 1; i++)
                graph[i] = new List<int>();

            for (int i = 0; i <= prerequisites.GetLength(0) - 1; i++)
                graph[prerequisites[i, 0]].Add(prerequisites[i, 1]);//curCourse=>preCourse,preCourse,...

            for (int i = 0; i <= graph.Length - 1; i++)
                if (!visited[i])
                    if (!DFS(graph, visited, new bool[numCourses], i))
                        return false;

            return true;
        }

        private bool DFS(List<int>[] graph, bool[] visited, bool[] currentPath, int course)
        {
            if (currentPath[course])
                return false;//cycle

            visited[course] = true;
            currentPath[course] = true;

            for (int i = 0; i < graph[course].Count; i++)
                if (!DFS(graph, visited, currentPath, graph[course][i]))
                    return false;

            currentPath[course] = false;

            return true;//no cycle
        }


		public bool CanFinishBFS(int numCourses, int[,] prerequisites)
		{
			if (numCourses == 0) return true;

			var graph = new Dictionary<int, HashSet<int>>();

			var inDegrees = new int[numCourses];//initialized with 0

			for (int i = 0; i < numCourses; i++)
			{
				graph[i] = new HashSet<int>();
			}

			for (int i = 0; i < prerequisites.GetLength(0); i++)
			{
				var preCourse = prerequisites[i, 1];
				var curCourse = prerequisites[i, 0];

				//graph[preCourse]=>curCourse
				graph[preCourse].Add(curCourse);
				//one preCourse=>one in-degree
				inDegrees[curCourse]++;
			}

			var isVisited = new HashSet<int>();

			var queue = new Queue<int>();

			for (int i = 0; i < inDegrees.Length; i++)
			{
				if (inDegrees[i] == 0)
				{
					queue.Enqueue(i);
					isVisited.Add(i);
				}
			}

			while (queue.Any())
			{
				var size = queue.Count;

				for (int s = 0; s < size; s++)
				{
					var cur = queue.Dequeue();
					inDegrees[cur]--;

					foreach (var course in graph[cur])
					{
						inDegrees[course]--;

						//if child course=>previously visited=>cycle
						if (isVisited.Contains(course)) return false;
					}
				}

				for (int i = 0; i < inDegrees.Length; i++)
				{
					if (inDegrees[i] == 0)
					{
						isVisited.Add(i);
						queue.Enqueue(i);
					}
				}
			}

			//why -1???
			if (inDegrees.Any(c => c != -1)) return false;

			return true;
		}
	}
}
