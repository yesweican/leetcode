public class Solution {
    public void Rotate(int[][] matrix) {
        int height = matrix.Length;;
        for (int i = 0; i < (height + 1) / 2; i ++) {
            for (int j = 0; j < height / 2; j++) {
               
                int temp = matrix[i][j];

                matrix[i][j] = matrix[height-j-1][i];
                matrix[height-j-1][i] = matrix[height-i-1][height-j-1];
                matrix[height-i-1][height-j-1] = matrix[j][height-i-1];
                matrix[j][height-i-1] = temp;
            }
        }
    }
