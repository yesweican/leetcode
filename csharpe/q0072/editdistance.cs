public class Solution {
    public int MinDistance(string word1, string word2) {
        
            int m = word1.Length;
            int n = word2.Length;
            int[,] d = new int[m + 1, n + 1];

            // Step 1
            if (m == 0)
            {
                return n;
            }

            if (n == 0)
            {
                return m;
            }

            // Step 2
            for (int i = 0; i <= m; i++)
            {
                d[i, 0] = i;
            }

            for (int j = 0; j <= n; j++)
            {
                d[0, j] = j;
            }

            // Step 3
            for (int i = 1; i <= m; i++)
            {
                //Step 4
                for (int j = 1; j <= n; j++)
                {
                    // Step 5
                    int cost = (word2[j - 1] == word1[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = min(d[i - 1, j] + 1, d[i, j - 1] + 1, d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[m, n];
        
    }
    
        private int min(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            else return z;
        }

}