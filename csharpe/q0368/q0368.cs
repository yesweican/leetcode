using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Largest Divisible Set - Recursive method, NOT performing enough 
    /// </summary>
    public class q368
    {
        HashSet<int> visited;
        int maxSize;
        Dictionary<int, List<int>> graph;
        List<int> result;
        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            result = new List<int>();

            if (nums.Length == 0)
            {
                return result;
            }
            if (nums.Length == 1)
            {
                result.Add(nums[0]);
                return result;
            }


            visited = new HashSet<int>();
            graph = new Dictionary<int, List<int>>();

            Array.Sort(nums);

            //Build the graph
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] == 0)
                    {
                        if (!graph.ContainsKey(nums[j]))
                        {
                            List<int> list = new List<int>();
                            list.Add(nums[i]);
                            graph.Add(nums[j], list);
                        }
                        else
                        {
                            graph[nums[j]].Add(nums[i]);

                        }
                        //break;
                    }
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (visited.Contains(nums[i]))
                    continue;

                dfs(nums[i], 1, new List<int>());
            }

            return result;
        }

        private void dfs(int root, int currentdepth, List<int> Path)
        {
            Path.Add(root);

            if (graph.ContainsKey(root))
            {
                for (int i = 0; i < graph[root].Count; i++)
                {
                    List<int> newPath = new List<int>(Path);
                    dfs(graph[root][i], currentdepth + 1, newPath);
                }
            }
            else//Root has not children
            {
                if (currentdepth > maxSize)
                {
                    maxSize = currentdepth;
                    result = Path;
                }

            }

            //put in visited after wards;
            visited.Add(root);

        }

    }

}
