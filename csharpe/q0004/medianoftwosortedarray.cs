public class Solution {
         ArrayList mergedArray = new ArrayList();   
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
             int totalCount=0;
            int n1 = 0 ; int n2 =0 ;
            while ((n1 < nums1.Length) && (n2 < nums2.Length))
            {
                if (nums1[n1] <= nums2[n2]) 
                {
                    mergedArray.Add(nums1[n1]);
                    n1++;
                    totalCount++;
                }
                else
                {
                    mergedArray.Add(nums2[n2]);
                    n2++;
                    totalCount++;
                }
            }

            if (n1 == nums1.Length)
            {
                while (n2 < nums2.Length)
                {
                    mergedArray.Add(nums2[n2]);
                    n2++;
                    totalCount++;
                }

            }

            if (n2 == nums2.Length)
            {
                while (n1 < nums1.Length)
                {
                    mergedArray.Add(nums1[n1]);
                    n1++;
                    totalCount++;
                }
            }

            if ((totalCount % 2) == 0)
            {
                double v1 = (int)mergedArray[totalCount / 2 - 1];
                double v2 = (int)mergedArray[totalCount / 2];

                return (double)((v1 + v2) / 2);
            }
            else
            {
                return (double)(int)mergedArray[(totalCount-1) / 2];
            }
        
    }
}