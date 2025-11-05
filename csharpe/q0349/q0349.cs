public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        HashSet<int> hash1 = new HashSet<int>();
        HashSet<int> hash2 = new HashSet<int>();

        for(int i=0; i<nums1.Length; i++) {
            if(!hash1.Contains(nums1[i])) {
                hash1.Add(nums1[i]);
            }
        }

        for(int i=0; i<nums2.Length; i++) {
            if(!hash2.Contains(nums2[i])) {
                hash2.Add(nums2[i]);
            }
        }

        List<int> result = new List<int>();
        var arr1 = hash1.ToArray();
        foreach(var v in arr1) {
            if(hash2.Contains(v)) {
                result.Add(v);
            }
        }

        return result.ToArray();
    }
}