using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //Alien Dictionary - Topoligical Sort && BFS
    public class q269
    {
        int[] indegrees;
        Dictionary<char, List<char>> graph;
        HashSet<char> subset;
        List<char> result;
        public string AlienOrder(string[] words)
        {
            indegrees = new int[26];
            graph = new Dictionary<char, List<char>>();
            subset = new HashSet<char>();
            result = new List<char>();

            //preparation 
            for(int i=1; i<words.Length; i++)
            {
                Process(words[i - 1], words[i]);
            }

            //topoligical sort
            Queue<char> queue = new Queue<char>();
            for(int i=0; i<26; i++)
            {
                if (indegrees[i] == 0)
                {
                    char c = (char)('a' + i);
                    if (subset.Contains(c))
                        queue.Enqueue(c);
                }
            }

            while(queue.Count>0)
            {
                int temp = queue.Count;
                for (int i = 0; i < temp; i++)
                {
                    char c = queue.Dequeue();

                    //Leaf character might not be in the graph key
                    if(graph.ContainsKey(c))
                    {
                        List<char> dependencies = graph[c];
                        for (int j = 0; j < dependencies.Count; j++)
                        {
                            char c2 = dependencies[j];
                            //update indegrees
                            indegrees[c2 - 'a']--;
                        }

                        graph.Remove(c);

                    }

                    subset.Remove(c);//to prevent the c reused again
                    result.Add(c);
                }

                //repopulate the queue
                for (int i = 0; i < 26; i++)
                {
                    if (indegrees[i] == 0)
                    {
                        char c = (char)('a' + i);
                        if (subset.Contains(c))
                            queue.Enqueue(c);
                    }
                }
            }

            //if graph is not empty, then there is an cycle!
            if (graph.Count > 0)
                return "";
            else
                return new string(result.ToArray());

        }

        private void Process(string s1, string s2)
        {
            int l = Math.Min(s1.Length, s2.Length);
            for (int i=0; i<l; i++)
            {
                if(s1[i]!=s2[i])
                {
                    if(!graph.ContainsKey(s1[i]))
                    {
                        graph[s1[i]] = new List<char>();
                        graph[s1[i]].Add(s2[i]);
                        //update indegree;
                        indegrees[s2[i] - 'a']++; //s1[i] would be one s2[i]'s in degree;
                    }
                    else
                    {
                        if(!graph[s1[i]].Contains(s2[i]))
                        {
                            graph[s1[i]].Add(s2[i]);
                            //update indegree;
                            indegrees[s2[i] - 'a']++; //s1[i] would be one s2[i]'s in degree;
                        }
                    }
                    /////////////////////////////////////////////////////////
                    ///populate the character subset
                    if (!subset.Contains(s1[i]))
                        subset.Add(s1[i]);
                    if (!subset.Contains(s2[i]))
                        subset.Add(s2[i]);

                    //should we bother with other characters in the words????
                    break;
                }    
            }

            return;
        }
    }

}
