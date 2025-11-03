public class Solution {
    IList<IList<int>> result;
    Dictionary<int, int> data;
    HashSet<string> hashSet;
    List<int> uniques;
    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        hashSet = new HashSet<string>();
        Array.Sort(candidates);
        data = new Dictionary<int, int>();
        for (int i = 0; i < candidates.Length; i++)
        {
            if (!data.Keys.Contains(candidates[i]))
                data.Add(candidates[i], 1);
            else
                data[candidates[i]]++;
        }

        uniques = data.Keys.ToList();
        result = new List<IList<int>>();
        List<int> temp = new List<int>();
        DFS(0, temp, target);
        return (IList<IList<int>>)result;
    }

    private void DFS(int pos, List<int> list, int target)
    {
        int currentVal = uniques[pos];
        if (currentVal == target)
        {
            List<int> newList2 = new List<int>(list);
            newList2.Add(currentVal);
            string entry = generateHash(newList2);

            if (!hashSet.Contains(entry))
            {
                result.Add((IList<int>)newList2);
                hashSet.Add(entry);
            }
        }
        else
        {
            if (target > currentVal)
            {
                for (int i = 1; i <= data[currentVal]; i++)
                {
                    List<int> newList3 = new List<int>(list);
                    for (int j = 0; j < i; j++)
                    {
                        newList3.Add(currentVal);
                    }

                    int newTarget = target - currentVal * i;
                    if (newTarget > 0 )
                    {
                        if( (pos + 1) < uniques.Count)
                            DFS(pos + 1, newList3, newTarget);
                    }
                    else
                    {
                        if (newTarget == 0)
                        {
                            string entry = generateHash(newList3);

                            if (!hashSet.Contains(entry))
                            {
                                result.Add((IList<int>)newList3);
                                hashSet.Add(entry);
                            }
                        }
                        else
                            break;
                    }

                }
            }
        }

        //skipping the currentVal ALL together
        List<int> newList = new List<int>(list);
        if ((pos + 1) < uniques.Count)
        {
            DFS(pos + 1, newList, target);
        }
    }

    private string generateHash(List<int> l)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(l[0].ToString());

        if (l.Count > 1)
        {
            for (int i = 1; i < l.Count; i++)
            {
                builder.Append("-" + l[i].ToString());
            }
        }

        return builder.ToString();
    }
}
