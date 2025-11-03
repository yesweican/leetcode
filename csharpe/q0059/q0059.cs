public class Solution {
    public int[][] GenerateMatrix(int n) {
        int[][] result = new int[n][];  

        for(int i=0; i<n; i++)
        {
            result[i] = new int[n];
        }

        int[][] directions = new int[4][]
        {new int[]{0,1},new int[]{1,0},new int[]{0,-1},new int[]{-1,0}};

        int currentrow = 0;
        int currentcol = 0;
        int counter = 1;

        int m = n - 1;
        while(m>=0) //break out on zero
        {
            //int steps = 4 * m;
            if(m==0)
            {
                result[currentrow][currentcol] = counter;
                break;
            }

            for (int r = 0; r < 4; r++)
            {
                int[] d = directions[r];

                if (r == 0 || r == 2)
                {
                    for (int i = 0; i < m; i++)
                    {
                        result[currentrow][currentcol] = counter;
                        counter++;
                        currentrow = currentrow + d[0];
                        currentcol = currentcol + d[1];
                    }
                }
                else //1 or 3
                {
                    for (int i = 0; i < m; i++)
                    {
                        result[currentrow][currentcol] = counter;
                        counter++;
                        currentrow = currentrow + d[0];
                        currentcol = currentcol + d[1];
                    }
                }
            }

            m -= 2;
            currentrow++;
            currentcol++;
        }

        return result;      
    }
}