using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q127
    {

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            int l = wordList.Count;
            HashSet<int> visited = new HashSet<int>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < wordList.Count; i++)
            {
                dict.Add(wordList[i], i + 1);
            }

            if (!dict.ContainsKey(endWord))
                return 0;

            int endIndex = dict[endWord];

            int[,] matrix = new int[l + 1, l + 1];

            for (int i = 0; i < l; i++)
            {
                matrix[i, i] = 0;

                for (int j = i + 1; j < l + 1; j++)
                {
                    if (i == 0)
                    {
                        //get the distance between beginword and wordlist[j-1]
                        if (OneDifference(beginWord, wordList[j - 1]))
                        {
                            matrix[0, j] = 1; matrix[j, 0] = 1;
                        }

                        else
                        {
                            matrix[0, j] = 0; matrix[j, 0] = 0;
                        }

                    }
                    else
                    {
                        //get the distance between wordList[i-1] and wordlist[j-1]
                        if (OneDifference(wordList[i - 1], wordList[j - 1]))
                        {
                            matrix[i, j] = 1; matrix[j, i] = 1;
                        }

                        else
                        {
                            matrix[i, j] = 0; matrix[j, i] = 0;
                        }
                    }
                }
            }

            visited.Add(0);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int step = 0;

            while (queue.Count > 0)
            {
                step++;

                int temp = queue.Count;

                for (int i = 0; i < temp; i++)
                {
                    int j = queue.Dequeue();
                    if (j == endIndex)
                        return step;

                    for (int k = 1; k < l + 1; k++)
                    {
                        if ((matrix[j, k] == 1) && (!visited.Contains(k)))
                        {
                            visited.Add(k);
                            queue.Enqueue(k);
                        }
                    }

                }
            }

            return 0;
        }

        private bool OneDifference(string s1, string s2)
        {
            char[] chars1 = s1.ToCharArray();
            char[] chars2 = s2.ToCharArray();
            if (chars1.Length != chars2.Length)
                return false;

            int counter = 0;
            for (int i = 0; i < chars1.Length; i++)
            {
                if (chars1[i] != chars2[i])
                    counter++;
                if (counter > 1)
                    return false;
            }

            return true;
        }
    }
}
