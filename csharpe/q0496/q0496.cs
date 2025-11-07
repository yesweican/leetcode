public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        Dictionary<int, int> locs = new Dictionary<int, int>();
        
        for(int i=0; i<nums2.Length; i++)
        {
            locs.Add(nums2[i], i);
        }
        
        List<int> result=new List<int>();
        
        for (int j=0; j<nums1.Length; j++)
        {
            int temp = nums1[j];
            bool found =false;
           
            for(int k=locs[temp]+1; k<nums2.Length; k++)
            {
                if(k<nums2.Length && nums2[k]>temp)
                {
                    found =true;
                    result.Add(nums2[k]);
                    break;
                };
            }
            
            if(found == false)
                result.Add(-1);
        }
        
        return result.ToArray();
    }
}