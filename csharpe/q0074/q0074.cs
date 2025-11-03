public class Solution {
    int width=-1;
    int height=-1;
    public bool SearchMatrix(int[][] matrix, int target) {
        height = matrix.Length;
        width = matrix[0].Length;
        
        int[] lastColumn = new int[height];

        for(int i=0; i<height; i++)
        {
            lastColumn[i] = matrix[i][width-1];
        }

        var index = Array.BinarySearch(lastColumn, target);

        if(index>=0)
            return true;

        int row = ~index;

        if(row>=height)
            return false;

        index = Array.BinarySearch(matrix[row], target);

        if(index>=0)
            return true;
        
        return false;
    }
}