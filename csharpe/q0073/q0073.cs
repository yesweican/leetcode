public class Solution {
    public void SetZeroes(int[][] matrix) {
        HashSet<int> allOneRows = new HashSet<int>();
        HashSet<int> allOneColumns = new HashSet<int>();

        for(int row = 0; row<matrix.Length; row++)
        {
            bool hasZero = false;
            for(int col = 0; col<matrix[row].Length; col++)
            {
                if(matrix[row][col]==0)
                {
                    hasZero = true;
                    break;
                }
            }

            if (!hasZero)
                allOneRows.Add(row);
        }

        for (int col = 0; col < matrix[0].Length; col++)
        {
            bool hasZero = false;
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row][col] == 0)
                {
                    hasZero = true;
                    break;
                }
            }

            if (!hasZero)
                allOneColumns.Add(col);
        }

        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (!allOneRows.Contains(row) || !allOneColumns.Contains(col))
                {
                    matrix[row][col] = 0;
                }
            }
        }      
    }
}