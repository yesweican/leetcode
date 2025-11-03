public class Solution {
    int rows, cols;
    public bool SearchMatrix(int[][] matrix, int target) {
        rows = matrix.Length;
        cols = matrix[0].Length;

        int lastrow = -1;
        for(int i=0; i<rows; i++)
        {
            if(matrix[i][0]==target)
                return true;
            if(matrix[i][0]>target)
            {
                lastrow = i-1;
                break;               
            }
         }

         if(lastrow==-1)
            lastrow= rows-1;

         for(int i=0; i<=lastrow;i++)
         {
             int index = Array.BinarySearch(matrix[i], target);
             if(index>=0)
                return true;
         }

         return false;
    }
}