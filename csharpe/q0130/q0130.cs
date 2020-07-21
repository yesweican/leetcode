using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    /// <summary>
    /// Surrounding Regions
    /// </summary>
    public class q130
    {
        public void Solve(char[][] board)
        {
            int Height = board.Length;
            if (Height == 0)
                return;
            int Width = board[0].Length;
            if (Width == 0)
                return;
            int[][] directions = new int[4][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 } };
            HashSet<string> visited=new HashSet<string>();

            List<int[]> startingPoints = new List<int[]>();

            for (int i=0; i<Width; i++)
            {
                startingPoints.Add(new int[] { 0, i });
                startingPoints.Add(new int[] { Height - 1, i });
            }

            for(int i=1; i<Height-1; i++)
            {
                startingPoints.Add(new int[] { i,0 });
                startingPoints.Add(new int[] {i, Width-1 });
            }

            Queue<int[]> queue = new Queue<int[]>();

            for(int i=0; i<startingPoints.Count; i++)
            {
                if(board[startingPoints[i][0]][startingPoints[i][1]]=='O' && !visited.Contains(startingPoints[i][0].ToString() + "-" + startingPoints[i][1].ToString()))
                {
                    //perform BFS using the queue
                    queue.Enqueue(startingPoints[i]);
                    visited.Add(startingPoints[0].ToString() + "-" + startingPoints[1].ToString());
                    while(queue.Count>0)
                    {
                        int[] point = queue.Dequeue();
                        board[point[0]][point[1]] = '$';//mark it perserved
                        foreach(var d in directions)
                        {
                            int[] newpoint = new int[2];
                            newpoint[0] = point[0] + d[0];
                            newpoint[1] = point[1] + d[1];
                            if(newpoint[0]>=0 && newpoint[0]<Height && newpoint[1]>=0 && newpoint[1]<Width)
                            {
                                //add the new point ONLY if it was never visited
                                if(board[newpoint[0]][newpoint[1]]=='O' && !visited.Contains(newpoint[0].ToString()+"-"+newpoint[1].ToString()))
                                {
                                    queue.Enqueue(newpoint);
                                    visited.Add(newpoint[0].ToString() + "-" + newpoint[1].ToString());
                                }
                            }
                        }
                    }
                }

            }//end of For

            for (int i = 0; i < Height; i++)
            {
                for(int j=0; j<Width; j++)
                {
                    if (board[i][j] == 'O')
                        board[i][j] = 'X';
                    if (board[i][j] == '$')
                        board[i][j] = 'O';
                }

            }

        }
    }
}
