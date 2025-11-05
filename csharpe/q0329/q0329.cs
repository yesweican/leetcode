    public class Solution
    {
        int[][] directions = new int[4][]{
           new int[2]{0,-1},
           new int[2]{0, 1},
           new int[2]{-1, 0},
           new int[2]{1,0}
        };

        int[][] data;
        int[][] dp;
        int rows = -1;
        int columns = -1;

        public int LongestIncreasingPath(int[][] matrix)
        {
            int maxLength = Int32.MinValue;
            rows = matrix.Length;
            columns = matrix[0].Length;
            data = matrix;
            ////////////////////////////
            //prep DP
            dp = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                dp[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    dp[i][j] = Int32.MinValue;
                }
            }
            ////Prep Step #2
            Dictionary<int[], int> grid2 = new Dictionary<int[], int>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int[] temp = new int[] { i, j };
                    grid2.Add(temp, data[i][j]);
                }
            }

            var sortedCells = grid2.ToArray();
            //sorting Reverse ordered 
            Array.Sort(sortedCells, (x, y) => (y.Value - x.Value));


            //setting the starting point
            for(int i=0; i<sortedCells.Length; i++)
            {
                int x = sortedCells[i].Key[0];
                int y = sortedCells[i].Key[1];

                int localLength = DFS(x, y, 1);
                dp[x][y] = localLength;
                if (localLength > maxLength)
                     maxLength = localLength;
            }

            return maxLength;
        }

        private int DFS(int x, int y, int currentLength)
        {
            int currentVal = data[x][y];
            int localMax = currentLength;

            data[x][y] = Int32.MinValue;

            for (int i = 0; i < 4; i++)
            {
                int newX = x + directions[i][0];
                int newY = y + directions[i][1];
                //
                if ((newX >= 0 && newX < rows) && (newY >= 0 && newY < columns))
                {
                    if (data[newX][newY] > currentVal)
                    {
                        int temp = -1;

                        if (dp[newX][newY] == Int32.MinValue)
                        {
                            temp = DFS(newX, newY, currentLength + 1);
                        }
                        else
                        {
                            temp = currentLength + dp[newX][newY];
                            if (temp > localMax)
                            {
                                localMax = temp;
                            }
                        }

                        if (temp > localMax)
                        {
                            localMax = temp;
                        }

                    }

                }

            }

            //backTracking
            data[x][y] = currentVal;

            return localMax;

        }
    }