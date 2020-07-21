using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class q733
    {
        public int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            int oldcolor = image[sr][sc];

            if (oldcolor == newColor)
                return image;

            return BFS(image, sr, sc, oldcolor, newColor);
        }

        public int[][] BFS(int[][] image, int sr, int sc, int oldcolor, int newColor)
        {
            int rows = image.Length;
            int cols = image[0].Length;
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[2] { sr, sc });

            while (q.Count > 0)
            {
                int[] current = q.Dequeue();
                int r0 = current[0]; int c0 = current[1];
                image[r0][c0] = newColor;

                for (int i = 0; i < 4; i++)
                {
                    int r = r0 + directions[i][0]; int c = c0 + directions[i][1];
                    if ((r >= 0) && (r < rows) && (c >= 0) && (c < cols))
                    {
                        if (image[r][c] == oldcolor)
                        {
                            q.Enqueue(new int[] { r, c });
                        }
                    }
                }
            }

            return image;
        }
    }
}
