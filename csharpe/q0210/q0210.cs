using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
	/// <summary>
	/// Course Schedule II
	/// </summary>
    public class q210
    {
		public int[] FindOrder(int numCourses, int[][] prerequisites)
		{

			List<int> results = new List<int>();

			if (numCourses == 0) return new int[0];

			var graph = new Dictionary<int, HashSet<int>>();

			var inDegrees = new int[numCourses];//initialized with 0

			for (int i = 0; i < numCourses; i++)
			{
				graph[i] = new HashSet<int>();
			}

			for (int i = 0; i < prerequisites.GetLength(0); i++)
			{
				var preCourse = prerequisites[i][1];
				var curCourse = prerequisites[i][0];

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
					results.Add(i);
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
						if (isVisited.Contains(course)) return new int[0];
					}
				}

				for (int i = 0; i < inDegrees.Length; i++)
				{
					if (inDegrees[i] == 0)
					{
						isVisited.Add(i);
						queue.Enqueue(i);
						results.Add(i);
					}
				}
			}

			if (inDegrees.Any(c => c != -1)) return new int[0];

			return results.ToArray();
		}
	}
}
