using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenge04
{
    /// <summary>
    /// Fruits into Basket - Two Pointers Sliding Window
    /// </summary>
    public class q904
    {
        public int TotalFruit(int[] tree)
        {
            int max = -1;

            Dictionary<int, int> map = new Dictionary<int, int>();

            int backpointer = 0; int forward = 0; int current = 0;
            while (forward < tree.Length)
            {
                if (map.ContainsKey(tree[forward]))
                {
                    //adding a fruit of existing kind
                    map[tree[forward]] = forward;
                    current++;
                    if (current > max)
                        max = current;
                }
                else
                {
                    if (map.Count < 2)
                    {
                        //adding a fruit of new kind
                        map.Add(tree[forward], forward);
                        current++;
                        if (current > max)
                            max = current;
                    }
                    else
                    {
                        //the basket already had two kinds of fruits and cannot add third;
                        int earlieritem = -1;
                        int earlierend = Int32.MaxValue;
                        foreach (var v in map)
                        {
                            if (v.Value < earlierend)
                            {
                                earlieritem = v.Key;
                                earlierend = v.Value;
                            }
                        }

                        backpointer = earlierend + 1;
                        map.Remove(earlieritem);
                        map.Add(tree[forward], forward);
                        //update current running length
                        current = forward - backpointer + 1;

                    }
                }
                //move forward pointer
                forward++;
            }

            return max;
        }
    }
}
