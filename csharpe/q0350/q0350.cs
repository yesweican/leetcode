public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        Dictionary<int, int> dict1 = new Dictionary<int, int>();
        Dictionary<int, int> dict2 = new Dictionary<int, int>();
        HashSet<int> set1 = new HashSet<int>();
        HashSet<int> set2 = new HashSet<int>();

        for(int i=0; i<nums1.Length; i++)
        {
            if(!dict1.Keys.Contains(nums1[i]))
            {
                dict1.Add(nums1[i], 1);
                set1.Add(nums1[i]);
            }
            else
            {
                dict1[nums1[i]] = dict1[nums1[i]] + 1;
            }
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (!dict2.Keys.Contains(nums2[i]))
            {
                dict2.Add(nums2[i], 1);
                set2.Add(nums2[i]);
            }
            else
            {
                dict2[nums2[i]] = dict2[nums2[i]] + 1;
            }
        }

        set1.IntersectWith(set2);

        List<int> result = new List<int>();
        foreach(var i in set1)
        {
            int temp = (dict1[i] < dict2[i]) ? dict1[i] : dict2[i];
            for(int j=0; j<temp; j++)
            {
                result.Add(i);
            }
        }

        return result.ToArray();       
    }
}